using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacaoDeEmail;

namespace ValidacaoEmail.Test
{
    public class ValidacaoEmailUnitTest
    {
        [Theory]
        [InlineData("murilo@email.com")]
        [InlineData("eduemail.com")]
        public void ValidarSeOEmailPossuiEndereco(string email)
        {

            Assert.True(Email.ValidarEnderecoEmail(email));
        }

        [Theory]
        [InlineData("murilo@email.com")]
        [InlineData("heitor@emailcom")]
        public void ValidarSeOEmailPossuiOPonto(string email)
        {
            Assert.True(Email.ValidarPontoEnderecoEmail(email));
        }
    }
}
