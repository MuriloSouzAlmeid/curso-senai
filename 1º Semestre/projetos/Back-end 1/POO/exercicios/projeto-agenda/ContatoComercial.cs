using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_agenda
{
    public class ContatoComercial : Contato, IContatoComercial
    {
        public string Cnpj { get; set; }

        public void ValidarCnpj(string _cnpj)
        {
            while(_cnpj.Length != 14){
                Console.WriteLine($"\nCNPJ informado inválido, informe um novo CNPJ:");
                _cnpj = Console.ReadLine()!;
            }
            this.DocumentoIdentidade = _cnpj;
        }
    }
}