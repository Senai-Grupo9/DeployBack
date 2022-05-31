//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Senai_fabNew.webAPI.Domains;
//using Senai_fabNew.webAPI.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Senai_fabNew.webAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class JsonController : ControllerBase
//    {
//        private readonly IJsonRepository _jsonRepository;

//        public JsonController(IJsonRepository context)
//        {
//            _jsonRepository = context;
//        }

//        [HttpGet("ReadJson")]
//        public IActionResult ReadJson()
//        {
//            try
//            {
//                return Ok(_jsonRepository.LerJson());
//            }
//            catch (Exception erro)
//            {

//                return BadRequest(erro);
//            }
//        }

//        [HttpGet("RegenerateJson")]
//        public IActionResult RegenerateJson()
//        {
//            try
//            {
                
//                return Ok(_jsonRepository.RegenerateJson());
//            }
//            catch (Exception erro)
//            {

//                return BadRequest(erro);
//            }
//        }

//        [HttpPut("UpdateJson")]
//        public IActionResult Put(Json JsonAtt)
//        {
//            try
//            {
//                return Ok(_jsonRepository.UpdateJson(JsonAtt));
//            }
//            catch (Exception erro)
//            {

//                return BadRequest(erro);
//            }
//        }
//    }
//}
