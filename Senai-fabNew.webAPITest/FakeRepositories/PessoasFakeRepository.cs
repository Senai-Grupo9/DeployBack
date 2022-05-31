using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPITest.FakeRepositories
{
    class PessoasFakeRepository : IPessoaRepository
    {
        private readonly List<Pessoa> _pessoa;

        public PessoasFakeRepository()
        {
            _pessoa = new List<Pessoa>()
            {
                new Pessoa()
                {
                    Nome = "claudio",
                    Faceid = "5462376578234",
                    Imagem = "claudio.jpg",
                    Verificado = true,
                    IdPessoa = 1
                }
            };
        }

        public void Alterar(int id, Pessoa PessoaAtt)
        {
            throw new NotImplementedException();
        }

        public Pessoa BuscarPorFaceId(string face_id)
        {
            return _pessoa.Where(a => a.Faceid == face_id)
            .FirstOrDefault();
        }

        public Pessoa BuscarPorId(int id)
        {
            return _pessoa.Where(a => a.IdPessoa == id)
            .FirstOrDefault();
        }

        public Pessoa BuscarPorNome(string nome)
        {
            return _pessoa.Where(a => a.Nome == nome)
            .FirstOrDefault();
        }

        public string Cadastrar(Pessoa Pessoa, string base64Image)
        {
            Pessoa.IdPessoa = 1;
            _pessoa.Add(Pessoa);
            return Pessoa.ToString();
        }

        public void Excluir(int usuario)
        {
            var existing = _pessoa.First(a => a.IdPessoa == usuario);
            _pessoa.Remove(existing);
        }

        public IEnumerable<Pessoa> Listar()
        {
            return _pessoa;
        }

        Pessoa IPessoaRepository.Cadastrar(Pessoa Pessoa, string base64Image)
        {
            throw new NotImplementedException();
        }
    }
}
