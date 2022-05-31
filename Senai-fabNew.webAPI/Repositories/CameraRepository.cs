using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json.Linq;
using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Repositories
{
    public class CameraRepository : ICameraRepository
    {
        private readonly ComputerVisionClient client;

        private const string subscriptionKey = "d17a33e9bce6410da71be697adf661bd";
        private const string endpoint = "https://fab-vision.cognitiveservices.azure.com/";

        private readonly ITipoObjetoRepository t_repository;
        private readonly IRegistroObjetoRepository r_repository;

        public CameraRepository(ITipoObjetoRepository tcontexto, IRegistroObjetoRepository rcontexto)
        {
            client = Authenticate(endpoint, subscriptionKey);
            t_repository = tcontexto;
            r_repository = rcontexto;

            //Run();
        }

        //public async void MakeRegisters(object o)
        //{
        //    var objects = await AnalyzeImageUrl(GetSnapshot().Result);

        //    var objs = t_repository.DetectarObjetos(objects);

        //    r_repository.AtualizaPresenca(objs.ToList());

        //    Console.WriteLine("Eu tentei!");
        //}

        //public void Test(object o)
        //{
        //    RegistroObjeto r = new()
        //    {
        //        CheckIn = DateTime.Now,
        //        CheckOut = DateTime.Now,
        //        IdTipoObj = 
        //    };
        //    r_repository.Cadastrar(r);
        //}

        //internal void Run()
        //{
        //    int seconds = 5 * 1000;

        //    var timer = new Timer(Test, null, 0, seconds);

        //    Console.ReadKey();
        //}

        //public async void MakeRegisters(string image)
        //{
        //    var objects = await c_repository.AnalyzeImageUrl(image);

        //    var objs = t_repository.DetectarObjetos(objects);

        //    ro_repository.AtualizaPresenca(objs.ToList());
        //}

        public ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
              new(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }

        public async Task<List<DetectedObject>> AnalyzeImageUrl(string imageUrl)
        {
            // Creating a list that defines the features to be extracted from the image. 
            List<VisualFeatureTypes?> features = new()
            {
                //VisualFeatureTypes.Categories,
                //VisualFeatureTypes.Description,
                //VisualFeatureTypes.Faces,
                //VisualFeatureTypes.ImageType,
                //VisualFeatureTypes.Tags,
                //VisualFeatureTypes.Adult,
                //VisualFeatureTypes.Color,
                //VisualFeatureTypes.Brands,
                VisualFeatureTypes.Objects
            };

            try
            {
                ImageAnalysis results = await client.AnalyzeImageAsync(imageUrl, visualFeatures: features);
                return results.Objects as List<DetectedObject>;
            }
            catch
            {
                return (null);
            }
        }

        public async Task<string> GetSnapshot()
        {
            const string url = "https://api.meraki.com/api/v1/devices/Q2SV-W46D-WS4H/camera/generateSnapshot";
            const string token = "cac23a2d135c93de4eb604fc142f4fbe07c4df1c";

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + token);

            try
            {
                WebResponse response = await request.GetResponseAsync();
                using StreamReader reader = new(response.GetResponseStream());
                string responseContent = reader.ReadToEnd();
                return responseContent.Split('"')[3];
            }
            catch (WebException webException)
            {
                return null;

                //if (webException.Response != null)
                //{
                //    using StreamReader reader = new(webException.Response.GetResponseStream());
                //    string responseContent = reader.ReadToEnd();
                //    return responseContent;
                //}
            }

            //return null;
        }
    }
}
