using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPITest.FakeRepositories
{
    class ObjetosFakeRepository : IObjetoRepository
    {
        private readonly List<Objeto> _objeto;

        public ObjetosFakeRepository()
        {
            _objeto = new List<Objeto>()
            {
                new Objeto()
                {
                    Nome = "cadeira",
                    Imagem = "cadeira.jpg",
                    Verificado = true,
                }
            };
        }

        public void Alterar(int id, Objeto objetoAtt)
        {
            throw new NotImplementedException();
        }

        public Objeto BuscarPorID(int id)
        {
            return _objeto.Where(a => a.IdObj == id)
            .FirstOrDefault();
        }

        public Objeto BuscarPorNome(string nome)
        {
            return _objeto.Where(a => a.Nome == nome)
            .FirstOrDefault();
        }

        public string Cadastrar(Objeto objeto, string formFile)
        {
            objeto.IdObj = 1;
            _objeto.Add(objeto);
            return objeto.ToString();
        }

        public void Excluir(int usuario)
        {
            var existing = _objeto.First(a => a.IdObj == usuario);
            _objeto.Remove(existing);
        }

        public IEnumerable<Objeto> Listar()
        {
            return _objeto;
        }
    }
}
