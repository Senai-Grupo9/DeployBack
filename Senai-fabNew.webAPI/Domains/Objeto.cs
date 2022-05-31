using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_fabNew.webAPI.Domains
{
    public partial class Objeto
    {
        public Objeto()
        {
            RegistroObjetos = new HashSet<RegistroObjeto>();
        }

        public byte IdObj { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public bool? Verificado { get; set; }

        public virtual ICollection<RegistroObjeto> RegistroObjetos { get; set; }
    }
}
