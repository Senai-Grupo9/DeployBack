using Azure.Storage.Blobs;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private const string conexao = "DefaultEndpointsProtocol=https;AccountName=arqfab;AccountKey=fO3tcCeb17hxYsj65jQ0RQ7T2/b8WqTn1NlEZ8xu7tb2YWZoAOFRt/Akm6FmlqX8jo3sT1tpTvr1eJ7DclMAww==;EndpointSuffix=core.windows.net";
        private const string container = "imagens";


        public string DownloadFromBlob(string filename)
        {
            var pasta = Path.Combine("StaticFiles", "SalvarBlob", filename);
            var path = Path.Combine(Directory.GetCurrentDirectory(), pasta);

            new BlobClient(conexao, container, filename).DownloadTo(path);

            return path;
        }

        public string Upload(string base64)
        {
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64, "");

            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient(conexao, container, fileName);

            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            return fileName;
        }
    }
}