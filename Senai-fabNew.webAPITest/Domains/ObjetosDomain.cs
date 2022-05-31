using Senai_fabNew.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Senai_fabNew.webAPITest.Domains
{
    public class ObjetosDomain
    {
        [Fact]
        public void DeveRetornarObjetoValido()
        {
            //arrange

            Objeto objeto = new Objeto();
            objeto.IdObj = 1;
            objeto.Imagem = "cadeira.jpg";
            objeto.Nome = "cadeira";

            //act

            bool resultado;

            if (objeto.Nome != null)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            //assert

            Assert.True(resultado);
        }


        [Fact]
        public void RetornarObjetoInvalido()
        {
            Objeto objeto = new();

            objeto.IdObj = 1;
            objeto.Imagem = null;
            objeto.Nome = null;


            bool resultado;

            if (objeto.Nome == null)
            {
                resultado = true;
            }

            else
            {
                resultado = false;
            }

            Assert.True(resultado);
        }
    }
}
