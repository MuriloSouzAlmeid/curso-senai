using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProductsWebAPI;
using ProductsWebAPI.Domains;
using ProductsWebAPI.Interfaces;

namespace ProductsWebApi.Test
{
    public class ProductsWebApiUnitTests
    {
        //Teste [ata a funcionalidade de listar todos os produtos
        [Fact]
        public void GetTest()
        {
            //Arrage

            //Lista de produtos
            List<Products> listaDeProdutos = new List<Products>() 
            {
                new Products(){ Name = "O livro do Bill - Edição com brinde!", Price = 159 },
                new Products(){ Name = "LEGO Set Icons 10330 McLaren MP4/4 e Ayrton Senna 693 peças", Price = 799 }
            };

            //Cria um objeto de simulação do tipo ProductsRepository 
            var mockRepository = new Mock<IProductsRepository>();

            //Act

            //Configura o método "Get" do controller para que quando for acionado retorne a lista "mockada"
            mockRepository.Setup(x => x.Get()).Returns(listaDeProdutos);

            List<Products> listaBuscada = mockRepository.Object.Get();

            //Assert
            Assert.Equal(2, listaBuscada.Count);
        }

        [Theory]
        [InlineData("f105e1f7-315e-46c4-9c4a-327d63318b4e")]
        public void GetById(Guid idProduto)
        {
            List<Products> listaDeProdutos = new List<Products>()
            {
                new Products(){Id = Guid.Parse("f105e1f7-315e-46c4-9c4a-327d63318b4e"), Name = "Black Skull Creatine Turbo - 300g", 
                    Price = 38}
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.GetById(idProduto)).Returns(listaDeProdutos.FirstOrDefault(p => p.Id == idProduto)!);

            Products produtoBuscado = mockRepository.Object.GetById(idProduto);

            Assert.NotNull(produtoBuscado);
        }

        [Fact]
        public void PostTest()
        {
            //Cria o objeto
            Products novoProduto = new Products() { Name = "GGB Plast Jogo Muliformas de Encaixe 36 Peças Colorido", Price = 23 };

            //Cria a lista
            List<Products> listaDeProdutos = new List<Products>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Post(novoProduto)).Callback<Products>(x => listaDeProdutos.Add(novoProduto));

            //Act
            mockRepository.Object.Post(novoProduto);

            //Assert
            Assert.Contains(novoProduto, listaDeProdutos);
        }

        [Theory]
        [InlineData("55551e2c-6a67-4b31-a93e-512a24a68cf2")]
        public void DeleteTest(Guid idProduto)
        {            
            List<Products> listaDeProdutos = new List<Products>() 
            {
                new Products() {Id = Guid.Parse("55551e2c-6a67-4b31-a93e-512a24a68cf2"), Name = "Grand Theft Auto V - Premium Online Edition - Playstation 4", Price = 80}
            };

            Products produto = listaDeProdutos.FirstOrDefault(p => p.Id == idProduto)!;

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Delete(idProduto)).Callback(() => listaDeProdutos.Remove(produto));

            mockRepository.Object.Delete(idProduto);

            Assert.Empty(listaDeProdutos);
        }

        [Theory]
        [InlineData("ad149434-5425-4ae0-aee0-f7c332268ee8")]
        public void PutTest(Guid idProduto)
        {
            List<Products> listaDeProdutos = new List<Products>()
            {
                new Products() {Id = Guid.Parse("ad149434-5425-4ae0-aee0-f7c332268ee8"), Name = "Omo Sabão Líquido Lavagem Perfeita 3L", Price = 30}
            };

            Products produtoAtualizado = new Products() 
            {
                Name = "Downy Brisa Intenso - Amaciante Concentrado, 1,5L",
                Price = 23
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.Put(idProduto, produtoAtualizado)).Callback(() =>
            {
                Products produtoBuscado = listaDeProdutos.FirstOrDefault(p => p.Id == idProduto)!;
                produtoBuscado.Name = produtoAtualizado.Name;
                produtoBuscado.Price = produtoAtualizado.Price;
            });

            mockRepository.Object.Put(idProduto, produtoAtualizado);

            Products produto = listaDeProdutos.FirstOrDefault(p => p.Id == idProduto)!;

            Assert.Equal("Downy Brisa Intenso - Amaciante Concentrado, 1,5L", produto.Name);
            Assert.Equal(23, produto.Price);
        }
    }
}
