using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace utilizando_celular.operacoes_gerais
{
    public class Finalizador
    {
        public string FinalizarPrograma(){
            Console.WriteLine($"\nOk então, encerrando programa.");
            Console.WriteLine($"Pressione ENTER para finalizar:");
            Console.ReadLine();
            Environment.Exit(0);
            return "";
        }
    }
}