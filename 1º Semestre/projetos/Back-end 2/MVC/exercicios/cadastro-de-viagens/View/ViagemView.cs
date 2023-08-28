using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cadastro_de_viagens.Model;

namespace cadastro_de_viagens.View
{
    public class ViagemView
    {
        public void Listar(List<ViagemModel> lista){
            foreach(ViagemModel evento in lista){
                Console.WriteLine($"\nNome do Evento: {evento.Nome}");
                Console.WriteLine($"Descrição do Evento: {evento.Descricao}");
                Console.WriteLine($"Data do Evento: {evento.DataEvento:D} às {evento.DataEvento.Hour}:{evento.DataEvento.Minute}");
            }
        }

        public ViagemModel Cadastrar(){
            Console.WriteLine($"\nInsira o nome do evento:");
            string nomeInformado = Console.ReadLine()!;

            Console.WriteLine($"\nInforme a descrição do evento:");
            string descricaoInformada = Console.ReadLine()!;
            
            Console.WriteLine($"\nInforme o dia do evento:");
            string diaInformado = Console.ReadLine()!;

            Console.WriteLine($"\nInforme o mês do evento:");
            string mesInformado = Console.ReadLine()!;

            Console.WriteLine($"\nInforme o ano do evento:");
            string anoInformado = Console.ReadLine()!;

            Console.WriteLine($"\nInforme informe o horàrio em que o evento ocorrerá: (no formato hh:mm)");
            string horarioInformado = Console.ReadLine()!;

            return new ViagemModel(nomeInformado, descricaoInformada, anoInformado, mesInformado, diaInformado, horarioInformado);
        }
    }
}