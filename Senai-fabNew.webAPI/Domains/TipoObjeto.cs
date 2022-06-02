using System;
using System.Collections.Generic;

namespace Senai_fabNew.webAPI.Domains
{
    public partial class TipoObjeto
    {
        public TipoObjeto()
        {
            RegistroObjetos = new HashSet<RegistroObjeto>();
        }

        public long IdTipoObj { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<RegistroObjeto> RegistroObjetos { get; set; }
    }
}
