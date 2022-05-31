using Microsoft.AspNetCore.Mvc;
using Senai_fabNew.webAPI.Controllers;
using Senai_fabNew.webAPI.Domains;
using Senai_fabNew.webAPI.Interfaces;
using Senai_fabNew.webAPITest.FakeRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Senai_fabNew.webAPITest.Controllers
{
    public class PessoasControllerTest
    {
        private readonly PessoasController _Pcontroller;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IBlobRepository blobRepository;

        public PessoasControllerTest()
        {
            _pessoaRepository = new PessoasFakeRepository();
            _Pcontroller = new PessoasController(_pessoaRepository, blobRepository);
        }

        [Fact]
        public void GetReturnsCaseIsTypeObject()
        {
            var Ok_result = _Pcontroller.Get();

            Assert.IsType<OkObjectResult>(Ok_result as OkObjectResult);
        }

        [Fact]
        public void GetReturnsCountAllItemsFromList()
        {
            var Ok_result = _Pcontroller.Get() as OkObjectResult;

            var items = Assert.IsType<List<Pessoa>>(Ok_result.Value);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void GetByIdIdeitifyIfMethodReturnsObject()
        {
            var FoundResult = _Pcontroller.BuscarId(1);

            Assert.IsType<OkObjectResult>(FoundResult);
        }
    }
}
