using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);

        void Cadastrar(Usuario cadastrar);

        void Alterar(int id, Usuario usuarioAtt);

        void Excluir(int usuario);

        IEnumerable<Usuario> Listar();

        Usuario BuscarPorID(int id);
    }
}
