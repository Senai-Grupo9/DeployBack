//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Senai_fabNew.webAPI.Contexts;
//using Senai_fabNew.webAPI.Domains;
//using Senai_fabNew.webAPI.Interfaces;

//namespace Senai_fabNew.webAPI.Controllers
//{
//    //[Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RegistroPessoasController : ControllerBase
//    {
//        private readonly IRegistroPessoaRepository _registroPessoaRepository;

//        public RegistroPessoasController(IRegistroPessoaRepository context)
//        {
//            _registroPessoaRepository = context;
//        }

//        // GET: api/RegistroPessoas
//        [HttpGet]
//        public IActionResult Get()
//        {
//            try
//            {
//                return Ok(_registroPessoaRepository.Listar());
//            }
//            catch (Exception erro)
//            {

//                return BadRequest(erro);
//            }
//        }

//        // GET: api/RegistroPessoas/5
//        [HttpGet("{id}")]
//        public IActionResult BuscarId(int id)
//        {
//            try
//            {
//                return Ok(_registroPessoaRepository.BuscarPorID(id));
//            }
//            catch (Exception erro)
//            {

//                return BadRequest(erro);
//            }
//        }

//        // PUT: api/RegistroPessoas/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public IActionResult Put(byte id, RegistroPessoa registroPessoa)
//        {
//            try
//            {
//                _registroPessoaRepository.Alterar(id, registroPessoa);
//                return StatusCode(204);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }

//        // POST: api/RegistroPessoas
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public IActionResult PostRegistroObjeto (RegistroPessoa registroPessoa)
//        {
//            try
//            {
//                _registroPessoaRepository.Cadastrar(registroPessoa);

//                return StatusCode(201);

//            }
//            catch (Exception ex)
//            {

//                return BadRequest(ex);
//            }
//        }

//        // DELETE: api/RegistroPessoas/5
//        [HttpDelete("{id}")]
//        public IActionResult DeleteObjeto(byte id)
//        {
//            try
//            {
//                _registroPessoaRepository.Excluir(id);
//                return StatusCode(204);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }

//        [HttpDelete("ResetaRegistros")]
//        public IActionResult ResetaRegistros()
//        {
//            try
//            {
//                _registroPessoaRepository.ResetaLista();
//                return StatusCode(204);
//            }
//            catch (Exception erro)
//            {
//                return BadRequest(erro);
//            }
//        }
//    }
//}
