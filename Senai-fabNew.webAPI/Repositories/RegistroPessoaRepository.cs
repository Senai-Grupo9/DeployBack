using Microsoft.EntityFrameworkCore;
using Senai_fabNew.webAPI.Contexts;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Repositories
{
    public class RegistroPessoaRepository : IRegistroPessoaRepository
    {
        private readonly FabSenaiNewContext ctx;


        public RegistroPessoaRepository(FabSenaiNewContext appContext)
        {
            ctx = appContext;
        }
        public void Alterar(int id, RegistroPessoa RegistroPessoaAtt)
        {
            RegistroPessoa RpessoaBuscado = ctx.RegistroPessoas.Find(Convert.ToByte(id));

            if (RegistroPessoaAtt.CheckIn != null)
            {
                RpessoaBuscado.CheckIn = RegistroPessoaAtt.CheckIn;
            }

            if (RegistroPessoaAtt.CheckOut != null)
            {
                RpessoaBuscado.CheckOut = RegistroPessoaAtt.CheckOut;
            }

            if (RegistroPessoaAtt.IdPessoa != null)
            {
                RpessoaBuscado.IdPessoa = RegistroPessoaAtt.IdPessoa;
            }

            ctx.RegistroPessoas.Update(RpessoaBuscado);
            ctx.SaveChanges();
        }

        public RegistroPessoa BuscarPorID(int id)
        {
            return ctx.RegistroPessoas
                .Select(u => new RegistroPessoa()
                {
                    IdRegistroPessoa = u.IdRegistroPessoa,
                    CheckIn = u.CheckIn,
                    CheckOut = u.CheckOut,
                    IdPessoa = u.IdPessoa,
                })
                .FirstOrDefault(u => u.IdRegistroPessoa == id);
        }

        public void Cadastrar(RegistroPessoa RegistroPessoa)
        {
            ctx.RegistroPessoas.Add(RegistroPessoa);
            ctx.SaveChanges();
        }

        public void Excluir(int RegistroPessoa)
        {
            RegistroPessoa RpessoaBuscado = BuscarPorID(RegistroPessoa);

            ctx.RegistroPessoas.Remove(RpessoaBuscado);

            ctx.SaveChanges();
        }

        public IEnumerable<RegistroPessoa> Listar()
        {
            return ctx.RegistroPessoas.Include(C => C.IdPessoaNavigation.Nome);
        }

        public List<RegistroPessoa> Now()
        {
            return ctx.RegistroPessoas.Where(r => r.CheckOut == null).ToList();
        }

        public void AtualizaPresenca(List<Pessoa> peopleNow)
        {
            List<RegistroPessoa> registers = Now();
            var now = DateTime.Now;

            if (peopleNow != null)
            {
                foreach (var p in peopleNow.ToList())
                {
                    foreach (var r in registers)
                    {
                        if (r.IdPessoa == p.IdPessoa)
                        {
                            peopleNow.Remove(p);
                            registers.Remove(r);
                            break;
                        }
                    }
                }

                foreach (var people in peopleNow.ToList())
                {
                    RegistroPessoa r = new()
                    {
                        IdPessoa = people.IdPessoa,
                        CheckIn = now,
                        CheckOut = null,
                    };
                    Cadastrar(r);
                }
            }

            foreach (var register in registers.ToList())
            {
                register.CheckOut = now;
                Alterar(register.IdRegistroPessoa, register);
            }
        }

        public void ResetaLista()
        {
            List<RegistroPessoa> RpessoaBuscada = Listar().ToList();

            foreach (var item in RpessoaBuscada)
            {
                ctx.RegistroPessoas.Remove(item);
            }
            ctx.SaveChanges();
        }
    }
}