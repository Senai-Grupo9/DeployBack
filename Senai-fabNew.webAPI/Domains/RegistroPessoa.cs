using System;
using System.Collections.Generic;

namespace Senai_fabNew.webAPI.Domains
{
    public partial class RegistroPessoa
    {
        public long IdRegistroPessoa { get; set; }
        public long? IdPessoa { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}
