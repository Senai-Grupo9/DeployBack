using System;
using System.Collections.Generic;

namespace Senai_fabNew.webAPI.Domains
{
    public partial class RegistroObjeto
    {
        public byte IdRegistroObj { get; set; }
        public byte? IdTipoObj { get; set; }
        public byte? IdPessoa { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual TipoObjeto IdTipoObjNavigation { get; set; }
    }
}
