using System;
using System.Collections.Generic;

namespace Senai_fabNew.webAPI.Domains
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            RegistroObjetos = new HashSet<RegistroObjeto>();
            RegistroPessoas = new HashSet<RegistroPessoa>();
        }

        public byte IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Faceid { get; set; }
        public bool? Verificado { get; set; }

        public virtual ICollection<RegistroObjeto> RegistroObjetos { get; set; }
        public virtual ICollection<RegistroPessoa> RegistroPessoas { get; set; }
    }
}
