using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;
using Senai_fabNew.webAPI.Interfaces;
using Senai_fabNew.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Nancy.Json;
using Nancy.Json.Simple;
using System.Drawing;
using System.Net;
using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Senai_fabNew.webAPI.Domains;
using System.Threading;

namespace Senai_fabNew.webAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraRepository c_repository;
        private readonly IFaceRepository f_repository;
        private readonly IRegistroPessoaRepository rp_repository;
        private readonly IRegistroObjetoRepository ro_repository;
        private readonly ITipoObjetoRepository t_repository;

        public CameraController(ICameraRepository ccontexto, IFaceRepository fcontexto, IRegistroPessoaRepository rpcontexto, IRegistroObjetoRepository rocontexto, ITipoObjetoRepository tcontexto)
        {
            c_repository = ccontexto;
            f_repository = fcontexto;
            rp_repository = rpcontexto;
            ro_repository = rocontexto;
            t_repository = tcontexto;
        }

        //[HttpPost("MakeRegisters")]
        //public async Task<IActionResult> VerificarRegistro(string image)
        //{
        //    var objects = await c_repository.AnalyzeImageUrl(image);

        //    var objs = t_repository.DetectarObjetos(objects);

        //    ro_repository.AtualizaPresenca(objs.ToList());
        //    return Ok(ro_repository.Listar());
        //}

        [HttpPost("MakeRegisters/Camera")]
        public async Task<IActionResult> VerificarRegistroCamera()
        {
            string image = await c_repository.GetSnapshot();

            if (image == null)
            {
                return BadRequest("imagem erro");
            }

            var objects = await c_repository.AnalyzeImageUrl(image);

            if (objects == null)
            {
                return BadRequest("Sobrecarga no reconhecimento, tente novamente mais tarde.");
            }

            var objs = t_repository.DetectarObjetos(objects);

            ro_repository.AtualizaPresenca(objs.ToList());
            return Ok(ro_repository.Listar());
        }

        //[HttpPost("MakeRegisters/Person")]
        //public async Task<IActionResult> VerificarRegistroPessoa(string image)
        //{
        //    //var image = await c_repository.GetSnapshot();

        //    var objects = await c_repository.AnalyzeImageUrl(image);
        //    List<DetectedObject> lista = objects.Where(p => p.ObjectProperty == "person").ToList();

        //    List<Pessoa> nowPeople = f_repository.DetectPeopleDetected(image, lista);
        //    // return Ok(nowPeople);

        //    rp_repository.AtualizaPresenca(nowPeople);
        //    return Ok(rp_repository.Listar());
        //}

        //[HttpPost("MakeRegisters/Object")]
        //public async Task<IActionResult> VerificarRegistroObjeto(string image)
        //{

        //    var objects = await c_repository.AnalyzeImageUrl(image);
        //    List<DetectedObject> lista = objects.Where(p => p.ObjectProperty != "person").ToList();

        //    var objs = t_repository.DetectarObjetos(lista);
        //    //return Ok(objs);

        //    ro_repository.AtualizaPresenca(objs.ToList());
        //    return Ok(ro_repository.Listar());
        //}

        //[HttpPut("ImageAnalyseUrl/PeopleIdentify")]
        //public async Task<IActionResult> VerificarPessoa(string url)
        //{
        //    var objects = await c_repository.AnalyzeImageUrl(url);
        //    List<DetectedObject> lista = objects.Where(p => p.ObjectProperty == "person").ToList();

        //    List<Pessoa> nowPeople = f_repository.DetectPeopleDetected(url, lista);
        //    return Ok(nowPeople);
        //}

        //[HttpPut("ImageAnalyseUrl")]
        //public async Task<IActionResult> VerificarImagem(string url)
        //{
        //    var objects = await c_repository.AnalyzeImageUrl(url);
        //    return Ok(objects);
        //}

        List<DetectedObject> lastResult;

        [HttpGet("ImageAnalyse")]
        public async Task<IActionResult> VerificarCamera()
        {
            do
            {
                var image = await c_repository.GetSnapshot();
                List<DetectedObject> result = null;

                if (image != null)
                {
                    result = await c_repository.AnalyzeImageUrl(image);

                    if (result != null)
                    {
                        if (result.Any())
                        {
                            return Ok(result);
                        }
                    }
                }

                Thread.Sleep(5000);

            } while (true);
        }

        [HttpGet("GetSnapshot")]
        public async Task<IActionResult> ObterSnapshot()
        {
            try
            {
                var resposta = await c_repository.GetSnapshot();
                return Ok(resposta);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
