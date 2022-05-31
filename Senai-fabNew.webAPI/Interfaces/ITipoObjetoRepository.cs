using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface ITipoObjetoRepository
    {
        void Cadastrar(TipoObjeto objeto);

        void Alterar(int id, TipoObjeto objetoAtt);

        void Excluir(int objeto);

        IEnumerable<TipoObjeto> Listar();

        TipoObjeto BuscarPorID(int id);

        TipoObjeto BuscarPorNome(string nome);

        IEnumerable<TipoObjeto> DetectarObjetos(List<DetectedObject> lista);
    }
}
