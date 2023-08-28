using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace utilizando_celular
{
    public class Celular
    {
        // Atributos
        public string Cor = "Black Piano";
        public string Modelo = "Realme 6s";
        public string Tamanho = "6.5";
        public bool Ligado;

        // Métodos
        public string MostaStatus(){
             return (Ligado) ? $"\n" + this.Modelo + " Ligado" : $"\n" + this.Modelo + " Desligado";
        }

        public string Ligar(){
            this.Ligado = true;
            Console.WriteLine($"\nLigando o {this.Modelo}...");
            Thread.Sleep(2000);
            return this.MostaStatus();
        }

        public string Desligar(){
            this.Ligado = false;
            Console.WriteLine($"\nDesligando o {this.Modelo}...");
            Thread.Sleep(2000);
            return this.MostaStatus();
        }

        public void FazerLigacao(){
            Console.WriteLine($"\nInforme o Número que receberá a ligação:");
            string numero = Console.ReadLine()!;
            Console.WriteLine($"\n{numero}\nChamando...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nLigação recusada!");
        }

        public void EnviarMensagem(){
            Console.WriteLine($"\nInforme o Contato que receberá a mensagem:");
            string contato = Console.ReadLine()!;
            Console.WriteLine($"\nEnviando Mensagem para {contato}...");
            Thread.Sleep(3000);
            Console.WriteLine($"\nMensagem Enviada!");
        }
    }
}