using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_fabNew.webAPI.Interfaces
{
    public interface IBlobRepository
    {
        public string Upload(string filename);

        public string DownloadFromBlob(string filename);
    }
}
