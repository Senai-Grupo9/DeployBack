using System;
using System.Collections.Generic;

namespace Senai_fabNew.webAPI.Domains
{
    public partial class Usuario
    {
        public byte IdUser { get; set; }
        public byte? IdTipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUser IdTipoNavigation { get; set; }
    }
}
