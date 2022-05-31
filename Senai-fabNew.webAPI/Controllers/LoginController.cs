﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using Senai_fabNew.webAPI.Repositories;
using Senai_fabNew.webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository contexto)
        {
            _usuarioRepository = contexto;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return BadRequest("email ou senha incorretos");
                };

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipo.ToString()),
                    new Claim("role", usuarioBuscado.IdTipo.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("FabSenai-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meutoken = new JwtSecurityToken(
                    issuer: "Senai-fabNew.webAPI",
                    audience: "Senai-fabNew.webAPI",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meutoken)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
