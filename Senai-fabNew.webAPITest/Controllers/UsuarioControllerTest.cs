using Microsoft.AspNetCore.Mvc;
using Moq;
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
    public class UsuarioControllerTest
    {
        private readonly UsuariosController _Ucontroller;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioControllerTest()
        {
            _usuarioRepository = new UsuarioFakeRepository();
            _Ucontroller = new UsuariosController(_usuarioRepository);
        }

        [Fact]
        public void GetReturnsOk()
        {
            var Ok_result = _Ucontroller.Get();

            Assert.IsType<OkObjectResult>(Ok_result as OkObjectResult);
        }

        [Fact]
        public void GetReturnsAllItemsFromList()
        {
            var Ok_result = _Ucontroller.Get() as OkObjectResult;

            var items = Assert.IsType<List<Usuario>>(Ok_result.Value);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void GetByIdReturnsOk()
        {
            var FoundResult = _Ucontroller.BuscarId(1);

            Assert.IsType<OkObjectResult>(FoundResult);
        }
    }
}
