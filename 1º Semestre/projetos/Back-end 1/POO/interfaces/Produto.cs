using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produto_interface
{
    public class Produto
    {
        // Atributos (Propriedades)
        public int Codigo {get;set;}
        public string Nome {get;set;}
        public float Preco {get; set;}

        //Construtores
        public Produto(){}
        public Produto(int _codigo, string _nome, float _preco){
            this.Codigo = _codigo;
            this.Nome = _nome;
            this.Preco = _preco;
        }
    }
}