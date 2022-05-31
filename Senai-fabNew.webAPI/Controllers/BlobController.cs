//using Azure.Storage.Blobs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.WindowsAzure.Storage.Blob;
//using Senai_fabNew.webAPI.Interfaces;
//using Senai_fabNew.webAPI.Utils;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace Senai_fabNew.webAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BlobController : ControllerBase
//    {
//        private readonly IBlobRepository _Blobrepository;

//        public BlobController(IBlobRepository context)
//        {
//            _Blobrepository = context;
//        }

//        //[HttpGet("{FileToDownload}/{containerP:CloudBlobContainer}")]
//        //public IActionResult Download(string FileToDownload, CloudBlobContainer containerP)
//        //{
//        //    try
//        //    {
//        //        _Blobrepository.DownloadFromBlob(FileToDownload, containerP);
//        //        return Ok();
//        //    }
//        //    catch (Exception erro)
//        //    {
//        //        return BadRequest(erro);
//        //    }
//        //}

//        //[HttpPost]
//        //public IActionResult PostPessoa(IFormFile arquivo, [FromForm] string imagem64, [FromForm] string container)
//        //{

//        //    if (arquivo.Length > 0)
//        //    {
//        //        using (var ms = new MemoryStream())
//        //        {
//        //            //copia a imagem enviada para a memoria.
//        //            arquivo.CopyTo(ms);
//        //            //ToArray = são os bytes da imagem.
//        //            var Base64Image = ms.ToArray();
//        //            //nome do arquivo

//        //            string Img64 = Convert.ToBase64String(Base64Image);
//        //            //extensão do arquivo
//        //            arquivo.FileName.Split('.').Last();
//        //            //id_usuario

//        //            imagem64 = Img64;
//        //        }

//        //        _Blobrepository.UploadBase64Image(imagem64, container);
//        //        //}
//        //    }
//        //        return Ok();
//        //}
//    }
//}
