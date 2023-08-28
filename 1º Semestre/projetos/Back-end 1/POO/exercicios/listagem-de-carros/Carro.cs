using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace listagem_de_carros
{
    public class Carro
    {
        // Atributos
        public string Marca {get;set;}
        public string Cor {get;set;}

        // Construtores
        public Carro(){
        }
        public Carro(string marca, string cor){
            this.Marca = marca;
            this.Cor = cor;
        }
    }
}