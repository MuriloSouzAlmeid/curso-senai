using introducao_mvc.Model;

namespace introducao_mvc.View
{
    public class ProdutoView
    {
        //Método para exibir os dados da lista em um console
        public void Listar(List<Produto> produto)
        {
            foreach (Produto item in produto)
            {
                Console.WriteLine($"\nCódigo: {item.Codigo}");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Preço: {item.Preco:C2}");
            }
        }

        public Produto InformarProduto(){
            Produto novoProduto;

            Console.WriteLine($"\nInforme o código do produto a ser cadastrado: ");
            string codigoProduto = Console.ReadLine()!;

            Console.WriteLine($"\nInforme o nome do produto a ser cadastrado: ");
            string nomeProduto = Console.ReadLine()!;

            Console.WriteLine($"\nInforme o preço do produto a ser cadastrado: ");
            string precoProduto = Console.ReadLine()!;

            return novoProduto = new Produto(codigoProduto, nomeProduto, precoProduto);
        }
    }
}