using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IObjetoRepository
    {
        string Cadastrar(Objeto objeto, string formFile);

        void Alterar(int id, Objeto objetoAtt);

        void Excluir(int objeto);

        IEnumerable<Objeto> Listar();

        Objeto BuscarPorID(int id);

        Objeto BuscarPorNome(string nome);
    }
}
