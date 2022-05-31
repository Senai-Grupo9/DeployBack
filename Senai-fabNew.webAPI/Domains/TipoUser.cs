using System;
using System.Collections.Generic;

namespace Senai_fabNew.webAPI.Domains
{
    public partial class TipoUser
    {
        public TipoUser()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdTipo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
