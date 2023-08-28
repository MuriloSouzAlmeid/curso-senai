using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_produto_interface{
    public class Carrinho : ICarrinho{
        // Atributos
        public float Valor {get;set;}

        // Lista de Produtos 
        List<Produto> carrinhoDeProdutos = new List<Produto>();

        // Construtores
        public Carrinho(){}

        // Fechando Contrato (Implementando métodos da interface)
        public void AdicionarProduto(Produto _produto)
        {
            this.carrinhoDeProdutos.Add(_produto);
            Console.WriteLine($"\nProduto Cadastrado!");
        }

        public void ListarProdutos()
        {
            // Count conta os elementos em uma lista ou um array
            if(this.carrinhoDeProdutos.Count == 0){
                Console.WriteLine($"\nNão há produtos em seu carrinho para serem listados.");
            }else{
                foreach(Produto p in this.carrinhoDeProdutos){
                    Console.WriteLine($"\nCódigo: {p.Codigo}. Nome: {p.Nome}. Preço: {p.Preco:C2}.");
                }
            }
        }

        public void AtualizarProduto(int _codigo)
        {
            bool produtoExiste = false;
            foreach(Produto p in carrinhoDeProdutos){
                if(p.Codigo == _codigo){
                    produtoExiste = true;
                }
            }
            if(produtoExiste){
                Console.WriteLine($"\nInforme o nome do novo produto:");
                (this.carrinhoDeProdutos.Find(x => x.Codigo == _codigo))!.Nome = Console.ReadLine()!;

                Console.WriteLine($"\nInforme o preço do novo produto:");
                (this.carrinhoDeProdutos.Find(x => x.Codigo == _codigo))!.Preco = float.Parse(Console.ReadLine()!);
                
                Console.WriteLine($"\nProduto Atualizado.");
            }else{
                Console.WriteLine($"\nNão há como realizar a atualização, pois não há produto no carrinho com o códido: {_codigo}");
                
            }
        }

        public void DeletarProduto(int _codigo)
        {
            bool produtoExiste = false;
            foreach(Produto p in carrinhoDeProdutos){
                if(p.Codigo == _codigo){
                    produtoExiste = true;
                }
            }
            if(produtoExiste){
                this.carrinhoDeProdutos.Remove(this.carrinhoDeProdutos.Find(x => x.Codigo == _codigo)!);
                Console.WriteLine($"\nProduto Removido!");
            }else{
                Console.WriteLine($"\nNão há como realizar a remoção, pois não há produto no carrinho com o códido: {_codigo}.");
            }
        }

        public void TotalCarrinho(){
            this.Valor = 0;
            if(this.carrinhoDeProdutos.Count == 0){
                Console.WriteLine($"\nO carrinho está vazio!");
            }else{
                foreach(Produto p in this.carrinhoDeProdutos){
                    Valor += p.Preco;
                }
                Console.WriteLine($"\nO valor atual do seu carrinho é: {this.Valor:C2}");
                
            }
        }
    }
}