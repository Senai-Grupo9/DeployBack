using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IJsonRepository
    {
        public string RegenerateJson();

        public string LerJson();

        public string UpdateJson(Json obj);
    }
}
