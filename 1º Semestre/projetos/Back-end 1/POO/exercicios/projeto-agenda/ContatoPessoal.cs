using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_agenda
{
    public class ContatoPessoal : Contato, IContatoPessoal
    {
        public string Cpf { get; set; }

        public void ValidarCpf(string _cpf)
        {
            while(_cpf.Length != 11){
                Console.WriteLine($"\nCPF informado inválido, informe um novo CPF:");
                _cpf = Console.ReadLine()!;
            }
            this.DocumentoIdentidade = _cpf;
        }
    }
}