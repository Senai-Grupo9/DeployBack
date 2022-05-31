using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using Senai_fabNew.webAPI.Utils;

namespace Senai_fabNew.webAPI.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IBlobRepository _blobRepository;


        public PessoasController(IPessoaRepository context, IBlobRepository Bcontext)
        {
            _pessoaRepository = context;
            _blobRepository = Bcontext;
        }

        // GET: api/Pessoas
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pessoaRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(_pessoaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("img/{FileToDownload}")]
        public IActionResult Download(string FileToDownload)
        {
            try
            {
                _blobRepository.DownloadFromBlob(FileToDownload);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(byte id, Pessoa pessoa)
        {
            try
            {
                _pessoaRepository.Alterar(id, pessoa);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostPessoa([FromForm] Pessoa pessoa, IFormFile arquivo)
        {
            string Img64;

            if (arquivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    //copia a imagem enviada para a memoria.
                    arquivo.CopyTo(ms);
                    //ToArray = são os bytes da imagem.
                    var Base64Image = ms.ToArray();
                    //nome do arquivo
                    Img64 = Convert.ToBase64String(Base64Image);
                    //extensão do arquivo
                    var extensao = Path.GetExtension(arquivo.FileName);
                }

                try
                {
                    return Ok(_pessoaRepository.Cadastrar(pessoa, Img64));
                }
                catch (Exception ex)
                {

                    return BadRequest(ex);
                }
            }
            return BadRequest();
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteObjeto(byte id)
        {
            try
            {
                _pessoaRepository.Excluir(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
