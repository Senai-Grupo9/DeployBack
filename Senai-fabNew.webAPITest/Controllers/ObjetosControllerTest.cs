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
    public class ObjetosControllerTest
    {
        private readonly TipoObjetoesController _Ocontroller;
        private readonly ITipoObjetoRepository _objetoRepository;
        private readonly IBlobRepository blobRepository;

        public ObjetosControllerTest()
        {
            //_objetoRepository = new ObjetosFakeRepository();
            _Ocontroller = new TipoObjetoesController(_objetoRepository, blobRepository);
        }

        [Fact]
        public void GetReturnsOk()
        {
            var Ok_result = _Ocontroller.Get();

            Assert.IsType<OkObjectResult>(Ok_result as OkObjectResult);
        }

        [Fact]
        public void GetReturnsAllItemsFromList()
        {
            var Ok_result = _Ocontroller.Get() as OkObjectResult;

            var items = Assert.IsType<List<Objeto>>(Ok_result.Value);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void GetByIdReturnsOk()
        {
            var FoundResult = _Ocontroller.BuscarId(1);

            Assert.IsType<OkObjectResult>(FoundResult);
        }
    }
}
