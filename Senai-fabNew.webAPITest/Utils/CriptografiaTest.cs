using Senai_fabNew.webAPI.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Senai_fabNew.webAPITest.Utils
{
    public class CriptografiaTest
    {
        [Fact]
        public void RetornarHashEmBcrypt()
        {
            //arrange

            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            //act 

            var retorno = regex.IsMatch(senha);

            //assert

            Assert.True(retorno);
        }

        [Fact]
        public void RetornarComparacaoValida()
        {
            //arrange

            var senha = "adm@132";
            var hash = "$2a$11$B5Xj1lWGTaVDW50pg9KG/ey0ab/vFZAYaVaYgHPfoSMtOVjrevrJG";

            //act

            var comparacao = Criptografia.Comparar(senha, hash);

            //assert

            Assert.True(comparacao);
        }
    }
}
