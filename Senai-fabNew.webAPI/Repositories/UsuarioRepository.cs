using Microsoft.EntityFrameworkCore;
using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using Senai_fabNew.webAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FabSenaiNewContext ctx;

        public UsuarioRepository(FabSenaiNewContext appContext)
        {
            ctx = appContext;
        }

        public void Alterar(int id, Usuario usuarioAtt)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(Convert.ToByte(id));

            if (usuarioAtt.IdTipo != null)
            {
                usuarioBuscado.IdTipo = usuarioAtt.IdTipo;
            }

            if (usuarioAtt.Email != null)
            {
                usuarioBuscado.Email = usuarioAtt.Email;
            }

            if (usuarioAtt.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtt.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorID(int id)
        {
            return ctx.Usuarios
                .Select(u => new Usuario()
                {
                    IdUser = u.IdUser,
                    IdTipo = u.IdTipo,
                    Email = u.Email,
                    Senha = u.Senha
                })
                .FirstOrDefault(u => u.IdUser == id);
        }

        public void Cadastrar(Usuario cadastrar)
        {
            ctx.Usuarios.Add(cadastrar);
            ctx.SaveChanges();
        }

        public void Excluir(int usuario)
        {
            Usuario usuarioBuscado = BuscarPorID(usuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public IEnumerable<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);
            var usuariofull = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuariofull != null)
            {
                usuariofull.Senha = Criptografia.GerarHash(senha);
                ctx.Update(usuariofull);
                ctx.SaveChanges();
                return usuariofull;
            }

            if (usuario != null)
            {
                bool comparado = Criptografia.Comparar(senha, usuario.Senha);

                if (comparado)
                    return usuario;
            }
            return null;
        }
    }
}
