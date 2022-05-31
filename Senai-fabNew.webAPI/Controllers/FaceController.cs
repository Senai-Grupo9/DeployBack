//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.CognitiveServices.Vision.Face;
//using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
//using Senai_fabNew.webAPI.Contexts;
//using Senai_fabNew.webAPI.Domains;
//using Senai_fabNew.webAPI.Interfaces;
//using Senai_fabNew.webAPI.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace Senai_fabNew.webAPI.Controllers
//{
//    //[Authorize]
//    [Produces("Application/json")]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FaceController : ControllerBase
//    {
//        private readonly IPessoaRepository p_repository;
//        private readonly IFaceRepository f_repository;


//        public FaceController(IPessoaRepository pcontexto, IFaceRepository fcontexto)
//        {
//            p_repository = pcontexto;
//            f_repository = fcontexto;
//        }

//        [HttpPost("FindSimilarPeople/Url")]
//        public async Task<IActionResult> FindSimilar(string url)
//        {
            
//            List<DetectedFace> faces = await f_repository.DetectFaceRecognize(url);

//            if (faces == null || !faces.Any()) { 
//                return BadRequest("There is no faces available on image"); 
//            }

//            List<Pessoa> pessoa = await f_repository.FindSimilar(faces);

//            if (pessoa == null) {
//                return NotFound("There is no people similar to this face"); 
//            }

//            return Ok(pessoa);
//        }

//        [HttpPost("FindSimiliarPeople/CroppedImage")]
//        public async Task<IActionResult> FindSimilarStream()
//        {
//            List<DetectedFace> faces = await f_repository.DetectFaceRecognize();

//            if (faces == null || !faces.Any())
//            {
//                return BadRequest("There is no faces available on image");
//            }

//            List<Pessoa> pessoa = await f_repository.FindSimilar(faces);

//            if (pessoa == null)
//            {
//                return NotFound("There is no people similar to this face");
//            }

//            return Ok(pessoa);
//        }
//    }
//}
