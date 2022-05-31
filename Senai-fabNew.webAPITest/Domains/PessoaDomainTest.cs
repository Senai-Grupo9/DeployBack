using Senai_fabNew.webAPI.Domains;
using Xunit;

namespace Senai_fabNew.webAPITest.Domains
{
    public class PessoaDomainTest
    {
        [Fact]
        public void RetornarPessoaPreenchido()
        {

            //arrange

            Pessoa pessoa = new();
            pessoa.IdPessoa = 1;
            pessoa.Imagem = "roberto.jpg";
            pessoa.Nome = "roberto";
            pessoa.Verificado = true;
            //act

            bool resultado;

            if (pessoa == null)
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }

            //assert

            Assert.True(resultado);
        }

        [Fact]
        public void RetornarUsuarioInvalido()
        {
            //arrange

            Pessoa pessoa = new();
            pessoa.IdPessoa = 1;
            pessoa.Imagem = "roberto.jpg";
            pessoa.Nome = "roberto";
            pessoa.Verificado = true;
            //act

            bool resultado;

            if (pessoa != null)
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

        
    }
}
