using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IRegistroObjetoRepository
    {
        void Cadastrar(RegistroObjeto RegistroObjeto);
        void Alterar(int id, RegistroObjeto RegistroObjetoAtt);
        void Excluir(int RegistroObjeto);
        IEnumerable<RegistroObjeto> Listar();
        RegistroObjeto BuscarPorID(int id);
        void AtualizaPresenca(List<TipoObjeto> objectNow);
        void ResetaLista();
        List<RegistroObjeto> Now();
    }
}
