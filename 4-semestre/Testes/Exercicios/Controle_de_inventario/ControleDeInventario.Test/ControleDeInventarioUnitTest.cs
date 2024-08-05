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
            Produto celular = inventario.FirstOrDefault(p => p.Nome == "celular");

            Assert.Equal(1, inventario.Count);
            Assert.Equal(1, celular.Quantidade);

            Produto.AdicionarProdutoAoInventario("celular", inventario);

            celular = inventario.FirstOrDefault(p => p.Nome == "celular");

            Assert.Equal(1, inventario.Count);
            Assert.Equal(2, celular.Quantidade);

            Produto.AdicionarProdutoAoInventario("tablet", inventario);

            celular = inventario.FirstOrDefault(p => p.Nome == "celular");

            Produto tablet = inventario.FirstOrDefault(p => p.Nome == "tablet");

            Assert.Equal(2, inventario.Count);
            Assert.Equal(2, celular.Quantidade);
            Assert.Equal(1, tablet.Quantidade);
        }

        [Fact]
        public void ValidarABuscaDaQuantidadeDoProdutoNoInventario()
        {

            List<Produto> inventario = new List<Produto>();

            Produto.AdicionarProdutoAoInventario("bota", inventario);

            int quantidade1 = Produto.BuscarQuantidadesDeUmProdutoNoInventario("bota", inventario);

            Assert.Equal(1, quantidade1);

            Produto.AdicionarProdutoAoInventario("bota", inventario);

            int quantidade2 = Produto.BuscarQuantidadesDeUmProdutoNoInventario("bota", inventario);

            Assert.Equal(2, quantidade2);
        }
    }
}
