using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IPessoaRepository
    {
        Pessoa Cadastrar(Pessoa Pessoa, string base64Image);

        void Alterar(int id, Pessoa PessoaAtt);

        void Excluir(int Pessoa);

        IEnumerable<Pessoa> Listar();

        Pessoa BuscarPorId(int id);

        Pessoa BuscarPorFaceId(string face_id);
    }
}
