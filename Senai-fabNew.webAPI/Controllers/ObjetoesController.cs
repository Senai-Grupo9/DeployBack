using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoObjetoesController : ControllerBase
    {
        private readonly ITipoObjetoRepository _objetoRepository;
        private readonly IBlobRepository _blobRepository;

        public TipoObjetoesController(ITipoObjetoRepository context, IBlobRepository Bcontext)
        {
            _objetoRepository = context;
            _blobRepository = Bcontext;
        }

        // GET: api/Objetoes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_objetoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        // GET: api/Objetoes/5
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(_objetoRepository.BuscarPorID(id));
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

        // PUT: api/Objetoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(byte id, TipoObjeto objetoAtt)
        {
            try
            {
                _objetoRepository.Alterar(id, objetoAtt);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Objetoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostObjeto(TipoObjeto objeto)
        {
            try
            {
                _objetoRepository.Cadastrar(objeto);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE: api/Objetoes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteObjeto(byte id)
        {
            try
            {
                _objetoRepository.Excluir(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
