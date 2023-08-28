using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace listas_objetos
{
    public class Produto
    {
        // Atributos
        public int Codigo {get;set;}
        public string Nome {get;set;}
        public float Preco{get;set;}

        // Construtores
        public Produto(){

        }
        public Produto(int codigo, string nome, float preco){
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}