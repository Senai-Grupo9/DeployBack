using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;

namespace Senai_fabNew.webAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroObjetoesController : ControllerBase
    {
        private readonly IRegistroObjetoRepository _registroObjeto;

        public RegistroObjetoesController(IRegistroObjetoRepository context)
        {
            _registroObjeto = context;
        }

        // GET: api/RegistroObjetoes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_registroObjeto.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("Now")]
        public IActionResult Registrossemsaida()
        {
            try
            {
                return Ok(_registroObjeto.Now());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // GET: api/RegistroObjetoes/5
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            try
            {
                return Ok(_registroObjeto.BuscarPorID(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        // PUT: api/RegistroObjetoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(byte id, RegistroObjeto RobjetoAtt)
        {
            try
            {
                _registroObjeto.Alterar(id, RobjetoAtt);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/RegistroObjetoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostRegistroObjeto(RegistroObjeto registroObjeto)
        {
            try
            {
                _registroObjeto.Cadastrar(registroObjeto);

                return StatusCode(201);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE: api/RegistroObjetoes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteObjeto(byte id)
        {
            try
            {
                _registroObjeto.Excluir(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("ResetaRegistros")]
        public IActionResult ResetaRegistros()
        {
            try
            {
                _registroObjeto.ResetaLista();
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
