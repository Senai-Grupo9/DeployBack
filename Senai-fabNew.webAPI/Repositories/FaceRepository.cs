using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Repositories
{
    public class FaceRepository : IFaceRepository
    {
        private readonly IPessoaRepository p_repository;
        private readonly IFaceClient client;
        private readonly IBlobRepository b_repository;

        public FaceRepository(IPessoaRepository pcontexto, IBlobRepository bcontext)
        {
            client = Authenticate(ENDPOINT, SUBSCRIPTION_KEY);
            p_repository = pcontexto;
            b_repository = bcontext;
        }

        const string SUBSCRIPTION_KEY = "490edecb000c4485a6959025c43a96e4";
        const string ENDPOINT = "https://ia-face-fabsenai.cognitiveservices.azure.com/";
        const string RECOGNITION_MODEL4 = RecognitionModel.Recognition04;
        private readonly string CROP_IMG_PATH = Directory.GetCurrentDirectory() + "\\StaticFiles\\cropped_image.jpg";

        private static IFaceClient Authenticate(string endpoint, string key)
        {
            return new FaceClient(new Microsoft.Azure.CognitiveServices.Vision.ComputerVision.ApiKeyServiceClientCredentials(key)) { Endpoint = endpoint };
        }

        public async Task<List<DetectedFace>> DetectFaceRecognize(string url)
        {
            IList<DetectedFace> detectedFaces = await client.Face.DetectWithUrlAsync(url, recognitionModel: RECOGNITION_MODEL4, detectionModel: DetectionModel.Detection03, returnFaceAttributes: new List<FaceAttributeType> { FaceAttributeType.QualityForRecognition });
            List<DetectedFace> sufficientQualityFaces = new();
            foreach (DetectedFace detectedFace in detectedFaces)
            {
                var faceQualityForRecognition = detectedFace.FaceAttributes.QualityForRecognition;
                if (faceQualityForRecognition.HasValue && (faceQualityForRecognition.Value >= QualityForRecognition.Medium))
                {
                    sufficientQualityFaces.Add(detectedFace);
                }
            }
            return sufficientQualityFaces.ToList();
        }

        public async Task<List<DetectedFace>> DetectFaceRecognize(Stream imagem)
        {
            IList<DetectedFace> detectedFaces = await client.Face.DetectWithStreamAsync(imagem, recognitionModel: RECOGNITION_MODEL4, detectionModel: DetectionModel.Detection03, returnFaceAttributes: new List<FaceAttributeType> { FaceAttributeType.QualityForRecognition });

            List<DetectedFace> sufficientQualityFaces = new();
            foreach (DetectedFace detectedFace in detectedFaces)
            {
                var faceQualityForRecognition = detectedFace.FaceAttributes.QualityForRecognition;
                if (faceQualityForRecognition.HasValue && (faceQualityForRecognition.Value >= QualityForRecognition.Medium))
                {
                    sufficientQualityFaces.Add(detectedFace);
                }
            }
            return sufficientQualityFaces.ToList();
        }

        public async Task<List<DetectedFace>> DetectFaceRecognize()
        {
            FileStream file_ = new(CROP_IMG_PATH, FileMode.Open, FileAccess.Read);
            List<DetectedFace> sufficientQualityFaces = new();

            try
            {
                IList<DetectedFace> detectedFaces = await client.Face.DetectWithStreamAsync(file_, recognitionModel: RECOGNITION_MODEL4, detectionModel: DetectionModel.Detection03, returnFaceAttributes: new List<FaceAttributeType> { FaceAttributeType.QualityForRecognition });

                foreach (DetectedFace detectedFace in detectedFaces)
                {
                    var faceQualityForRecognition = detectedFace.FaceAttributes.QualityForRecognition;
                    if (faceQualityForRecognition.HasValue && (faceQualityForRecognition.Value >= QualityForRecognition.Medium))
                    {
                        sufficientQualityFaces.Add(detectedFace);
                    }
                }
                return sufficientQualityFaces.ToList();
            }
            catch (Exception)
            {
                return sufficientQualityFaces.ToList();
            }
        }

        public async Task<List<Pessoa>> FindSimilar(List<DetectedFace> face)
        {
            string path = Directory.GetCurrentDirectory();

            List<Guid?> targetFaceIds = new();
            IEnumerable<Pessoa> targetImageFileNames = p_repository.Listar();


            foreach (var pessoa in targetImageFileNames)
            {
                b_repository.DownloadFromBlob(pessoa.Imagem);

                FileStream fs = new(path + "\\StaticFiles\\SalvarBlob\\" + pessoa.Imagem, FileMode.Open, FileAccess.Read);

                var faces = await DetectFaceRecognize(fs);

                pessoa.Faceid = faces[0].FaceId.Value.ToString();

                p_repository.Alterar(pessoa.IdPessoa, pessoa);

                targetFaceIds.Add(faces[0].FaceId.Value);

                fs.Close();
            }

            List<Pessoa> pessoas = new();
            foreach (var f in face)
            {
                try
                {
                    IList<SimilarFace> similarResults = await client.Face.FindSimilarAsync(f.FaceId.Value, null, null, targetFaceIds);
                    pessoas.Add(p_repository.BuscarPorFaceId(similarResults[0].FaceId.Value.ToString()));

                }
                catch
                {
                    
                }
            }

            return pessoas;
            //return similarResults;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validar a compatibilidade da plataforma", Justification = "<Pendente>")]
        public string CropImage(string url, Rectangle r)
        {
            WebClient wc = new();
            byte[] originalData = wc.DownloadData(url);

            MemoryStream stream = new(originalData);
            Bitmap b = new(stream);

            Bitmap nb = new(r.Width, r.Height);

            using (Graphics g = Graphics.FromImage(nb))
            {
                g.DrawImage(b, -r.X, -r.Y);
            }

            nb.Save(CROP_IMG_PATH, System.Drawing.Imaging.ImageFormat.Png);
            return CROP_IMG_PATH;
        }

        public List<Pessoa> DetectPeopleDetected(string url, List<DetectedObject> peopleObject)
        {
            if (!peopleObject.Any())
            {
                return null;
            }

            List<Pessoa> peopledetected = new();

            foreach (DetectedObject objeto in peopleObject)
            {
                Rectangle pos = new()
                {
                    X = objeto.Rectangle.X,
                    Y = objeto.Rectangle.Y,
                    Width = objeto.Rectangle.W,
                    Height = objeto.Rectangle.H,
                };

                List<DetectedFace> search;

                CropImage(url, pos);

                search = DetectFaceRecognize().Result;

                //se algum rosto foi detectado
                if (search.Any())
                {
                    var response = FindSimilar(search).Result;

                    if (!response.Any())
                    {
                        Pessoa p = new()
                        {
                            Nome = "Desconhecido",
                            Faceid = search[0].FaceId.Value.ToString(),
                            Verificado = false,
                        };

                        string Img64;
                        using (var ms = new MemoryStream())
                        {
                            FileStream file_ = new(CROP_IMG_PATH, FileMode.Open, FileAccess.Read);
                            file_.CopyTo(ms);
                            var Base64Image = ms.ToArray();
                            Img64 = Convert.ToBase64String(Base64Image);
                        }

                        peopledetected.Add(p_repository.Cadastrar(p, Img64));
                    }
                    else
                    {
                        peopledetected.Add(response[0]);
                    }
                }
            }

            return peopledetected;
        }
    }
}
