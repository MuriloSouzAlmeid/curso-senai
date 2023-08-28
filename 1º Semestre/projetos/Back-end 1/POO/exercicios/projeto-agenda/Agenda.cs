using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_agenda
{
    public class Agenda : IAgenda
    {
        List<Contato> contatos = new List<Contato>();

        public void AdicionarContato(Contato _contato)
        {
            this.contatos.Add(_contato);
            Console.WriteLine($"\nContato adicionado à agenda.");
        }

        public void ListarContatos()
        {
            if(contatos.Count == 0){
                Console.WriteLine($"\nA agenda está vazia");
                
            }else{
                foreach(Contato c in contatos){
                    if(c.DocumentoIdentidade.Length == 11){
                        Console.WriteLine($"\nContato Pessoal");
                    }else{
                        Console.WriteLine($"\nContato Comercial");
                    }
                    Console.WriteLine($"Nome: {c.Nome}");
                    Console.WriteLine($"Telefone: {c.Telefone}");
                    Console.WriteLine($"Email: {c.Email}");
                    if(c.DocumentoIdentidade.Length == 11){
                        Console.WriteLine($"CPF: {c.DocumentoIdentidade.Substring(0, 3)}.{c.DocumentoIdentidade.Substring(3, 3)}.{c.DocumentoIdentidade.Substring(6, 3)}-{c.DocumentoIdentidade.Substring(9)}");
                    }else{
                        Console.WriteLine($"CNPJ: {c.DocumentoIdentidade.Substring(0, 2)}.{c.DocumentoIdentidade.Substring(2, 3)}.{c.DocumentoIdentidade.Substring(5, 3)}/{c.DocumentoIdentidade.Substring(8, 4)}.{c.DocumentoIdentidade.Substring(12)}");
                    }
                }
            }
        }

        public void TotalContatos(){
            if(this.contatos.Count == 0){
                Console.WriteLine($"\nA agenda está vazia!");
            }else{
                Console.WriteLine($"\nTotal de contatos na agenda: {this.contatos.Count}");
            }
        }
    }
}