using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jogador_de_futebol
{
    public abstract class Jogador
    {
        public string Nome {get;set;}
        public DateTime Datanascimento {get;set;}
        public string Nacionalidade {get;set;}
        public float Peso {get;set;}

        public abstract void ImprimirDadosJogador();
        public abstract void CalcularIdadeJogador();
        public abstract void CalcularAposentadoriaJogador();
    }
}