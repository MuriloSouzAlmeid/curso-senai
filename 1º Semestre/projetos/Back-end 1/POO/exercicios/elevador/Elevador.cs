using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elevador
{
    public class Elevador
    {
        // Atributos
        public int AndarAtual { get; set; }
        public int TotalAndar { get; set; }
        public int CapacidadeElevador { get; set; }
        public int PessoasPresentes { get; set; }

        // Métodos
        public void Iniciar( int andares, int capacidade)
        {
            this.TotalAndar = andares;
            this.CapacidadeElevador = capacidade; 
        }

        public void Subir(){
            Console.WriteLine($"\nInforme a quantidade de andares que deseja subir:");
            int andaresInformados = int.Parse(Console.ReadLine()!);
            int andarFinal = andaresInformados + this.AndarAtual;
            if(this.AndarAtual == this.TotalAndar){
                Console.WriteLine($"\nNão é possível subir mais andares pois você já está no último andar!");
            } else if(andarFinal > this.TotalAndar){
                Console.WriteLine($"\nNão é possível subir esse tanto de andares pois não há andares suficiente!");
            }else{
                this.AndarAtual = andarFinal;
                Console.WriteLine($"\nSubindo...");
                Thread.Sleep(2000);
                Console.WriteLine($"\nVocê subiu para o {this.AndarAtual}º andar");
            }
            Console.WriteLine($"Pressione ENTER para retornar ao menu de ações:");
            Console.ReadLine();
        }
        public void Descer(){
            Console.WriteLine($"\nInforme a quantidade de andares que deseja descer:");
            int andaresInformados = int.Parse(Console.ReadLine()!);
            int andarFinal = this.AndarAtual - andaresInformados;
            if(this.AndarAtual == 0){
                Console.WriteLine($"\nNão é possível descer mais andares pois você já está no térreo!");
            }else if(andarFinal < 0){
                Console.WriteLine($"\nNão é possível descer esse tanto de andares pois não há andares o suficiente!");
            }else{
                this.AndarAtual = andarFinal;
                Console.WriteLine($"\nDescendo...");
                Thread.Sleep(2000);
                if(this.AndarAtual == 0){
                    Console.WriteLine($"\nVocê desceu para o térreo!");
                }else{
                    Console.WriteLine($"\nVocê desceu para o {this.AndarAtual}º andar!");
                }
            }
            Console.WriteLine($"Pressione ENTER para retornar ao menu de ações:");
            Console.ReadLine();
        }
        public void Entar(){
            Console.WriteLine($"\nInforme a quantidade de pessoas que entrarão no elevador:");
            int qtdInformada = int.Parse(Console.ReadLine()!);
            int pessoasFinal = this.PessoasPresentes + qtdInformada;
            if(this.PessoasPresentes == this.CapacidadeElevador){
                Console.WriteLine($"\nNão é possível entrar mais pessoas pois a capacidade do elevador foi atingida!");
            }else if(pessoasFinal > this.CapacidadeElevador){
                Console.WriteLine($"\nNão é possível entrar esse tanto de pessoas pois o elevdor não tem tal capacidade!");
            }
            else{
                Console.WriteLine($"\nEntrando...");
                Thread.Sleep(2000);
                this.PessoasPresentes = pessoasFinal;
                if(qtdInformada == 1){
                    Console.WriteLine($"\nUma pessoa acabou de entrar no elevador!");
                }else{
                    Console.WriteLine($"\n{qtdInformada} pessoas acabaram de entrar no elevador!");
                }
            }
            Console.WriteLine($"Pressione ENTER para retornar ao menu de ações:");
            Console.ReadLine();
        }
        public void Sair(){
            Console.WriteLine($"\nInforme a quantidade de pessoas que sairão do elevador:");
            int qtdInformada = int.Parse(Console.ReadLine()!);
            int pessoasFinal = this.PessoasPresentes - qtdInformada;
            if(this.PessoasPresentes == 0){
                Console.WriteLine($"\nNão é possível sair alguém pois o elevador está vazio!");
            }else if(pessoasFinal < 0){
                Console.WriteLine($"\nNão é possível sair tantas pessoas pois nem há esse mesmo tanto dentro do elevador!");
            }else{
                Console.WriteLine($"\nSaindo...");
                Thread.Sleep(2000);
                this.PessoasPresentes = pessoasFinal;
                if(qtdInformada == 1){
                    Console.WriteLine($"\nUma pessoa acabou de sair no elevador!");
                }else{
                    Console.WriteLine($"\n{qtdInformada} pessoas saíram do elevador!");
                }
            }
            Console.WriteLine($"Pressione ENTER para retornar ao menu de ações:");
            Console.ReadLine();
        }

    }
}