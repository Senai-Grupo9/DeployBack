using System;
using System.Collections.Generic;

namespace Senai_fabNew.webAPI.Domains
{
    public partial class RegistroObjeto
    {
        public long IdRegistroObj { get; set; }
        public long? IdTipoObj { get; set; }
        public long? IdPessoa { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual TipoObjeto IdTipoObjNavigation { get; set; }
    }
}
