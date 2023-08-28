using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace utilizando_celular.operacoes_gerais
{
    public class Verificador
    {

        bool opcaoValida;
        public string VerificarResposta(string respostaInformada, string[] listaAnalizada){
            this.opcaoValida = false;
            do{
                foreach(string opcao in listaAnalizada){
                    if(respostaInformada == opcao){
                        this.opcaoValida = true;
                        break;
                    }
                }
                if(this.opcaoValida == false){
                    Console.WriteLine($"Opção escolhida inválida, escolha entre as opções disponíveis acima:");
                    respostaInformada = Console.ReadLine()!.ToLower();
                }
            }while(this.opcaoValida == false);
            return respostaInformada;
        }
    }
}