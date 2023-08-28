using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_loja_virtual
{
    public class Pagamento
    {
        MenuClass menuPrograma = new MenuClass();
        public DateTime DataAtual {get; private set;} = DateTime.Now;
        public float ValorInicial;
        public double ValorFinal;

        public DateTime GerarData(){
            DateTime DataFinal = new DateTime(DataAtual.Year, DataAtual.Month, DataAtual.Day + 3, DataAtual.Hour, DataAtual.Minute, DataAtual.Second);
            return DataFinal;
        }
        public void Cancelar(){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nA operação será cancelada");
            Console.WriteLine($"Pressione ENTER para voltar ao menu...");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
}