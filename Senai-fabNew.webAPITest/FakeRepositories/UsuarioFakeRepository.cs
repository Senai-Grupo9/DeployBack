using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPITest.FakeRepositories
{
    class UsuarioFakeRepository : IUsuarioRepository
    {
        private readonly List<Usuario> _usuarios;

        public UsuarioFakeRepository()
        {
            _usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    Email = "adm@adm.com",
                    Senha = "adm@132"

                }
            };
        }


        public void Alterar(int id, Usuario usuarioAtt)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorID(int id)
        {
            return _usuarios.Where(a => a.IdUser == id)
            .FirstOrDefault();
        }

        public void Cadastrar(Usuario cadastrar)
        {
            cadastrar.IdUser = 1;
            _usuarios.Add(cadastrar);
        }

        public void Excluir(int usuario)
        {
            var existing = _usuarios.First(a => a.IdUser == usuario);
            _usuarios.Remove(existing);
        }

        public IEnumerable<Usuario> Listar()
        {
            return _usuarios;
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
