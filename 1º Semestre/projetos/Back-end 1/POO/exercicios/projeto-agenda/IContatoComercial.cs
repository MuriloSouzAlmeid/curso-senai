using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_agenda
{
    public interface IContatoComercial
    {
        void ValidarCnpj(string _cnpj);
    }
}