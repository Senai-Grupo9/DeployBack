using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
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
    public class TipoObjetoRepository :  ITipoObjetoRepository
    {
        private readonly FabSenaiNewContext ctx;
        private IBlobRepository _blobRepository;


        public TipoObjetoRepository(FabSenaiNewContext appContext, IBlobRepository context)
        {
            ctx = appContext;
            _blobRepository = context;
        }

        public void Alterar(int id, TipoObjeto objetoAtt)
        {
            TipoObjeto objetoBuscado = ctx.TipoObjetos.Find(Convert.ToByte(id));

            if (objetoAtt.Nome != null)
            {
                objetoBuscado.Nome = objetoAtt.Nome;
            }

            ctx.TipoObjetos.Update(objetoBuscado);
            ctx.SaveChanges();
        }

        public TipoObjeto BuscarPorID(int id)
        {
            return ctx.TipoObjetos
                .Select(u => new TipoObjeto()
                {
                    IdTipoObj = u.IdTipoObj,
                    Nome = u.Nome,
                })
                .FirstOrDefault(u => u.IdTipoObj == id);
        }

        public TipoObjeto BuscarPorNome(string nome)
        {
            return ctx.TipoObjetos
               .Select(u => new TipoObjeto()
               {
                   IdTipoObj = u.IdTipoObj,
                   Nome = u.Nome,
               })
               .FirstOrDefault(u => u.Nome == nome);
        }

        public void Cadastrar(TipoObjeto objeto)
        {
            ctx.TipoObjetos.Add(objeto);
            ctx.SaveChanges();
        }

        public void Excluir(int objeto)
        {
            TipoObjeto objetoBuscado = BuscarPorID(objeto);

            ctx.TipoObjetos.Remove(objetoBuscado);

            ctx.SaveChanges();
        }

        public IEnumerable<TipoObjeto> Listar()
        {
            return ctx.TipoObjetos.ToList();
        }

        public IEnumerable<TipoObjeto> DetectarObjetos(List<DetectedObject> lista)
        {
            List<TipoObjeto> objs = new();

            foreach (var item in lista)
            {
                var obj = BuscarPorNome(item.ObjectProperty);
                
                if (obj == null)
                {
                    TipoObjeto t = new()
                    {
                        Nome = item.ObjectProperty,
                    };

                    Cadastrar(t);
                    objs.Add(t);
                } else
                {
                    objs.Add(obj);
                }
            }

            return objs;
        }
    }
}
