using Senai_fabNew.webAPI.Domains;
using Xunit;

namespace Senai_fabNew.webAPITest.Domains
{
    public class UsuarioDomainTest
    {
        [Fact]
        public void RetornarUsuarioPreenchido()
        {

            //arrange

            Usuario usuario = new Usuario();
            usuario.Email = "adm@adm.com";
            usuario.Senha = "adm@132";

            //act

            bool resultado = true;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = false;
            }

            //assert

            Assert.True(resultado);
        }

        [Fact]
        public void RetornarUsuarioInvalido()
        {
            Usuario usuario = new();

            usuario.Email = null;
            usuario.Senha = null;


            bool resultado = false;

            if (usuario.Senha == null || usuario.Email == null)
            {
                resultado = true;
            }

            Assert.True(resultado);
        }

        
    }
}
