using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        [Fact]
        public void SomarDoisNumeros()
        {
            var n1 = 3.3;
            var n2 = 2.2;
            var valorEsperado = 5.5;

            var soma = Calculo.Somar(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

        [Fact]
        public void SubtrairDoisNumeros()
        {
            var n1 = 5.2;
            var n2 = 0.2;
            var valorEsperado = 5;

            var soma = Calculo.Subtrair(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

        [Fact]
        public void MultiplicarDoisNumeros()
        {
            var n1 = 7;
            var n2 = 10;
            var valorEsperado = 70;

            var soma = Calculo.Multiplicar(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

        [Fact]
        public void DividirDoisNumeros()
        {
            var n1 = 100;
            var n2 = 4;
            var valorEsperado = 25;

            var soma = Calculo.Dividir(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

        [Fact]
        public void TirarOModuloDeUmNumero()
        {
            var n1 = -250;
            var valorEsperado = 250;

            var soma = Calculo.Modulo(n1);

            Assert.Equal(valorEsperado, soma);
        }
    }
}
