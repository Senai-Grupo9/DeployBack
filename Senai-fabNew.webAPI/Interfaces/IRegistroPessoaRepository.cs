using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IRegistroPessoaRepository
    {
        void Cadastrar(RegistroPessoa RegistroPessoa);

        void Alterar(int id, RegistroPessoa RegistroPessoaAtt);

        void Excluir(int RegistroPessoa);

        IEnumerable<RegistroPessoa> Listar();

        RegistroPessoa BuscarPorID(int id);
        List<RegistroPessoa> Now();

        void AtualizaPresenca(List<Pessoa> peopleNow);
        void ResetaLista();

    }
}
