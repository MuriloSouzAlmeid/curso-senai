using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversaoTemperaturas
{
    public class ConverterTemperatura
    {
        public static double ConverterCelsiusParaFahrenheit(double tempC)
        {
            return ((tempC * 9)/5) + 32;
        }

        public static double ConverterFahrenheitParaCelsius(double tempF)
        {
            return ((tempF -32)/9)*5;
        }
    }
}
