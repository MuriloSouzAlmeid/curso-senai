using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeInventario.Test
{
    public class ControleDeInventarioUnitTest
    {


        [Fact]
        public void ValidarAAdicaoDoProdutoAoInventario()
        {
            List<Produto> inventario = new List<Produto>();

            Produto.AdicionarProdutoAoInventario("celular", inventario);
            Produto.AdicionarProdutoAoInventario("celular", inventario);

            Produto celular = inventario.FirstOrDefault(p => p.Nome == "celular");

            Assert.Equal(1, inventario.Count);
            Assert.Equal(2, celular.Quantidade);
        }

        [Fact]
        public void ValidarABuscaDaQuantidadeDoProdutoNoInventario()
        {

            List<Produto> inventario = new List<Produto>();

            inventario.Add(new Produto() 
            {
                Nome = "bota",
                Quantidade = 2
            });
            
            int quantidade = Produto.BuscarQuantidadesDeUmProdutoNoInventario("bota", inventario);

            Assert.Equal(2, quantidade);
        }
    }
}
