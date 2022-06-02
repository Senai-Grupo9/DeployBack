using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Senai_fabNew.webAPI.Repositories
{
    public class RegistroObjetoRepository : IRegistroObjetoRepository
    {

        private readonly FabSenaiNewContext ctx;

        public RegistroObjetoRepository(FabSenaiNewContext appContext)
        {
            ctx = appContext;
        }

        public void Alterar(int id, RegistroObjeto RegistroObjetoAtt)
        {
            RegistroObjeto RobjetoBuscado = ctx.RegistroObjetos.Find(Convert.ToByte(id));

            if (RegistroObjetoAtt.CheckIn != null)
            {
                RobjetoBuscado.CheckIn = RegistroObjetoAtt.CheckIn;
            }

            if (RegistroObjetoAtt.CheckOut != null)
            {
                RobjetoBuscado.CheckOut = RegistroObjetoAtt.CheckOut;
            }

            if (RegistroObjetoAtt.IdTipoObj != null)
            {
                RobjetoBuscado.IdTipoObj = RegistroObjetoAtt.IdTipoObj;
            }

            if (RegistroObjetoAtt.IdPessoa != null)
            {
                RobjetoBuscado.IdPessoa = RegistroObjetoAtt.IdPessoa;
            }

            ctx.RegistroObjetos.Update(RobjetoBuscado);
            ctx.SaveChanges();
        }

        public RegistroObjeto BuscarPorID(int id)
        {
            return ctx.RegistroObjetos
                .Select(u => new RegistroObjeto()
                {
                    IdRegistroObj = u.IdRegistroObj,
                    CheckIn = u.CheckIn,
                    CheckOut = u.CheckOut,
                    IdTipoObj = u.IdTipoObj,
                    IdPessoa = u.IdPessoa,
                })
                .FirstOrDefault(u => u.IdRegistroObj == id);
        }

        public void Cadastrar(RegistroObjeto RegistroObjeto)
        {
            ctx.RegistroObjetos.Add(RegistroObjeto);
            ctx.SaveChanges();
        }

        public List<RegistroObjeto> Now()
        {
            return ctx.RegistroObjetos.Where(r => r.CheckOut == null).OrderByDescending(r => r.CheckIn).Include(nav => (nav.IdTipoObjNavigation)).ToList();
        }

        public void AtualizaPresenca(List<TipoObjeto> objectNow)
        {
            List<RegistroObjeto> registers = Now();
            var now = DateTime.Now;

            if (objectNow != null)
            {
                foreach (var p in objectNow.ToList())
                {
                    foreach (var r in registers)
                    {
                        if (r.IdTipoObj == p.IdTipoObj)
                        {
                            objectNow.Remove(p);
                            registers.Remove(r);
                            break;
                        }
                    }
                }

                foreach (var o in objectNow.ToList())
                {

                    
                    RegistroObjeto r = new()
                    {
                        IdTipoObj = o.IdTipoObj,
                        CheckIn = now,
                        CheckOut = null,
                    };
                    Cadastrar(r);
                }
            }

            foreach (var register in registers.ToList())
            {
                var myint = unchecked((int)register.IdRegistroObj);

                register.CheckOut = now;
                Alterar(myint, register);
            }
        }

        public void ResetaLista()
        {
            List<RegistroObjeto> RobjetoBuscado = Listar().ToList();

            foreach (var item in RobjetoBuscado)
            {
                ctx.RegistroObjetos.Remove(item);
            }
            ctx.SaveChanges();
        }

        public void Excluir(int RegistroObjeto)
        {
            RegistroObjeto RobjetoBuscado = BuscarPorID(RegistroObjeto);

            ctx.RegistroObjetos.Remove(RobjetoBuscado);

            ctx.SaveChanges();
        }

        public IEnumerable<RegistroObjeto> Listar()
        {
            return ctx.RegistroObjetos.OrderByDescending(r => r.CheckOut).Include(nav => (nav.IdTipoObjNavigation)).ToList();
        }
    }
}
