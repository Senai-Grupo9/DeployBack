using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly FabSenaiNewContext ctx;
        private readonly IBlobRepository _blobRepository;

        public PessoaRepository(FabSenaiNewContext appContext, IBlobRepository context)
        {
            ctx = appContext;
            _blobRepository = context;
        }

        public void Alterar(int id, Pessoa PessoaAtt)
        {

            Pessoa pessoaBuscado = ctx.Pessoas.Find(Convert.ToByte(id));

            if (PessoaAtt.Nome != null)
            {
                pessoaBuscado.Nome = PessoaAtt.Nome;
            }

            if (PessoaAtt.Imagem != null)
            {
                pessoaBuscado.Imagem = PessoaAtt.Imagem;
            }

            if (PessoaAtt.Faceid != null)
            {
                pessoaBuscado.Faceid = PessoaAtt.Faceid;
            }

            if (PessoaAtt.Verificado != null)
            {
                pessoaBuscado.Verificado = PessoaAtt.Verificado;
            }

            ctx.Pessoas.Update(pessoaBuscado);
            ctx.SaveChanges();
        }

        public Pessoa BuscarPorId(int id)
        {
            return ctx.Pessoas
                .Select(u => new Pessoa()
                {
                    IdPessoa = u.IdPessoa,
                    Nome = u.Nome,
                    Imagem = u.Imagem,
                    Faceid = u.Faceid,
                    Verificado = u.Verificado,
                })
                .FirstOrDefault(u => u.IdPessoa == id);
        }

        public Pessoa BuscarPorFaceId(string face_id)
        {
            return ctx.Pessoas
                .Select(u => new Pessoa()
                {
                    IdPessoa = u.IdPessoa,
                    Nome = u.Nome,
                    Imagem = u.Imagem,
                    Faceid = u.Faceid,
                    Verificado = u.Verificado,
                })
                .FirstOrDefault(u => u.Faceid == face_id);
        }

        public Pessoa Cadastrar(Pessoa Pessoa, string base64)
        {
            var fileName = _blobRepository.Upload(base64);

            Pessoa.Imagem = fileName;
            ctx.Pessoas.Add(Pessoa);
            ctx.SaveChanges();

            return Pessoa;
        }

        public void Excluir(int pessoa_id)
        {
            Pessoa pessoaBuscado = ctx.Pessoas.Find(Convert.ToByte(pessoa_id));

            ctx.Pessoas.Remove(pessoaBuscado);

            ctx.SaveChanges();
        }

        public IEnumerable<Pessoa> Listar()
        {
            return ctx.Pessoas.ToList();
        }
    }
}
