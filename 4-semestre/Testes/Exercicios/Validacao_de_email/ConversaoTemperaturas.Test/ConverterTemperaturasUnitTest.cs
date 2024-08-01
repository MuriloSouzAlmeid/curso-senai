using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversaoTemperaturas;

namespace ConversaoTemperaturas.Test
{
    public class ConverterTemperaturasUnitTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void ValidarCoversaoDeTemperaturaCelsiusParaFahrenheit(double tempC)
        {
            double tempF = ConverterTemperatura.ConverterCelsiusParaFahrenheit(tempC);

            Assert.Equal(tempF, 50);
        }

        [Theory]
        [InlineData(212)]
        [InlineData(200)]
        public void ValidarCoversaoDeTemperaturaFahrenheitParaCelsius(double tempF)
        {
            double tempC = ConverterTemperatura.ConverterFahrenheitParaCelsius(tempF);

            Assert.Equal(tempC, 100);
        }
    }
}
