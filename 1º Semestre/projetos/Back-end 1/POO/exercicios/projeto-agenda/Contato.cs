using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_agenda
{
    public abstract class Contato
    {
        public string Nome {get;set;}
        public string Telefone {get;set;}
        public string Email {get;set;}
        public string DocumentoIdentidade {get;set;}
    }
}