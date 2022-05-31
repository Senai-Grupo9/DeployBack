using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IFaceRepository
    {
        Task<List<DetectedFace>> DetectFaceRecognize(string url);
        Task<List<DetectedFace>> DetectFaceRecognize(System.IO.Stream imagem);
        Task<List<DetectedFace>> DetectFaceRecognize();
        Task<List<Pessoa>> FindSimilar(List<DetectedFace> face);
        List<Pessoa> DetectPeopleDetected(string url, List<DetectedObject> peopleObject);
        string CropImage(string url, Rectangle r);
    }
}
