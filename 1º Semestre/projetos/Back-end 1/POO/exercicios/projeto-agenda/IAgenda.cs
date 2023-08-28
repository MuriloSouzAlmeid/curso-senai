using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_agenda
{
    public interface IAgenda
    {
        void AdicionarContato(Contato _contato);
        void ListarContatos();
    }
}