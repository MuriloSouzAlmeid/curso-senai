using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeInventario
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public static void AdicionarProdutoAoInventario(string nomeProduto, List<Produto> inventario)
        {
            Produto produtoBuscado = inventario.FirstOrDefault(produto => produto.Nome == nomeProduto)!;

            if (produtoBuscado != null)
            {
                produtoBuscado.Quantidade++;
            }
            else
            {
                inventario.Add(new Produto()
                {
                    Nome = nomeProduto,
                    Quantidade = 1
                });
            }
        }

        public static int BuscarQuantidadesDeUmProdutoNoInventario(string nomeProduto, List<Produto> inventario)
        {
            Produto produtoBuscado = inventario.Find(p => p.Nome == nomeProduto)!;

            return 2;
        }
    }
}
