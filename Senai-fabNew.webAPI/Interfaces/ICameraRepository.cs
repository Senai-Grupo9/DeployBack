using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface ICameraRepository
    {
        ComputerVisionClient Authenticate(string endpoint, string key);
        Task<List<DetectedObject>> AnalyzeImageUrl(string imageUrl);
        Task<string> GetSnapshot();
    }
}
