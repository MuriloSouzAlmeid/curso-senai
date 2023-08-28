using projeto_produto_interface;

Carrinho carrinhoDeCompras = new Carrinho();

string respostaMenu = "";
int codigoGerado = 0;

do{
    Console.Clear();
    carrinhoDeCompras.TotalCarrinho();

Console.WriteLine(@$"
Escolha Entre:
[1] Adicionar Produto
[2] Listar Produtos
[3] Alterar Produto
[4] Remover Produto
[0] Sair do Programa");
respostaMenu = Console.ReadLine()!;

    switch(respostaMenu){
        case "1":
            codigoGerado++;

            Console.WriteLine($"\nInforme o nome do Produto:");
            string nomeProduto = Console.ReadLine()!;

            Console.WriteLine($"\nInforme o preço do Produto:");
            float precoProduto = float.Parse(Console.ReadLine()!);

            Produto produtoAdicionado = new Produto(codigoGerado, nomeProduto, precoProduto);

            carrinhoDeCompras.AdicionarProduto(produtoAdicionado);
            
            break;
        
        case "2":
            carrinhoDeCompras.ListarProdutos();
            break;

        case "3":
            Console.WriteLine($"\nAtualização de Produto");
            Console.WriteLine($"\nInforme o código do produto a ser alterado:");
            int codigoNovoProduto = int.Parse(Console.ReadLine()!);

            carrinhoDeCompras.AtualizarProduto(codigoNovoProduto);
            
            break;   

        case "4":
            Console.WriteLine($"\nInforme o código do produto a ser removido:");
            int codigoInformado = int.Parse(Console.ReadLine()!);

            carrinhoDeCompras.DeletarProduto(codigoInformado);  
            break;

        case "0":
            Console.WriteLine($"\nPressione qualquer tecla para finalizar o programa...");
            Console.ReadLine();
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine($"\nOpção inválida");
            break;
    }
    Console.WriteLine($"\nPressione qualquer tecla retornar ao menu...");
    Console.ReadLine();
}while(respostaMenu != "0");
