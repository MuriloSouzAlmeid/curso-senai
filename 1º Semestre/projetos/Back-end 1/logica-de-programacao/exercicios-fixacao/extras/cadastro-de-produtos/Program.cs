// Cadastro de produtos

// Início

using System.Globalization;

Console.Clear();
Console.WriteLine($"\nCadastro de Produtos");


// ======================================================= Funções ====================================================================

static int MenuOpcoes(string[] nome, float[] preco, bool[] promocao, int posicaoFinal){
    string respostaContinuar = "";
    Console.WriteLine(@$"
--------------------------------------
|         CADASTRO DE PRODUTOS       |
--------------------------------------
| (1) -> Cadastrar Novos Produtos    |
| (2) -> Listar Produtos Cadastrados |
| (0) -> Sair do Programa            |
--------------------------------------");
string respostaMenu = Console.ReadLine()!;

while((respostaMenu != "1" && respostaMenu != "2" && respostaMenu != "0") || respostaMenu == ""){
    Console.WriteLine($"\nOpção informada inválida. Escolha entre (1) para cadastrar, (2) para listar ou (0) para finalizar o programa:");
    respostaMenu = Console.ReadLine()!; 
}

switch(respostaMenu){
    case "1":
        do{
            Console.Clear();
            if(posicaoFinal == (nome.Length)){
                Console.WriteLine($"\nNúmero máximo de produtos cadastrados atingido!");
                break;
            } else{
                
                    Console.Clear();
                    posicaoFinal = CadastrarProduto(nome, preco, promocao, posicaoFinal);
                    posicaoFinal++;
                    Console.WriteLine($"\nDeseja Cadastrar mais um produto? (s/n)");
                    respostaContinuar = Console.ReadLine()!.ToUpper();
                    VerificarResposta(respostaContinuar);
            }
        } while(respostaContinuar == "S");
        break;
    
    case "2":
        Console.Clear();
        ListaProdutos(nome, preco, promocao, posicaoFinal);
        break;
    
    case "0":
        FinalizaPrograma();
        break;
}

    return posicaoFinal;

}

// ------------------------------------------------------------------------------------------------------------------------------------

static string VoltarMenu(string respostaContinuar){
    Console.WriteLine($"\nDeseja retornar para Menu de Opções?");
    respostaContinuar =  Console.ReadLine()!.ToUpper();
    respostaContinuar = VerificarResposta(respostaContinuar);
    return respostaContinuar;
}

// ------------------------------------------------------------------------------------------------------------------------------------

static string VerificarResposta(string respostaInformada){
    while((respostaInformada != "S" && respostaInformada != "N") || respostaInformada == ""){
            Console.WriteLine($"\nOpção informada inválida, escolha entre (s) para sim e (n) para não");
            respostaInformada = Console.ReadLine()!.ToUpper();
    }

    return respostaInformada;
}

// ------------------------------------------------------------------------------------------------------------------------------------

static int CadastrarProduto(string[] nome, float[] preco, bool[] promocao, int posicao){
    Console.WriteLine($"\nInforme o nome do produto que será cadastrado:");
    nome[posicao] = Console.ReadLine()!;

    Console.WriteLine($"\nInforme o preço do produto que será cadastrado:");
    preco[posicao] = float.Parse(Console.ReadLine()!);

    Console.WriteLine($"\nInforme se o produto está em promoção: (s/n)");
    string respostaPromocao = Console.ReadLine()!.ToUpper();

    respostaPromocao = VerificarResposta(respostaPromocao);

    if(respostaPromocao == "S"){
        promocao[posicao] = true;
    } else{
        promocao[posicao] = false;
    }

    return posicao;
}

// ----------------------------------------------------------------------------------------------------------------------------------

static void ListaProdutos(string[] nome, float[] preco, bool[] promocao, int posicaoFinal){
    string informacaoPromocao = "";
        Console.Clear();
        Console.WriteLine($"\nLista de Produtos Cadastrados\n");
        for(int contador = 0; contador < posicaoFinal; contador++){
            if(promocao[contador] == true){
                informacaoPromocao = "O produto está em Promoção";
            } else{
                informacaoPromocao = "O produto não está em Promoção";
            }
            Console.WriteLine(@$"
{contador + 1}) Nome: {nome[contador]}. 
   Preço: {preco[contador].ToString("C", new CultureInfo("pt-br"))}
   {informacaoPromocao}.");
        }
}

// ----------------------------------------------------------------------------------------------------------------------------------

static void FinalizaPrograma(){
    Console.WriteLine($"\nOk Senhor(a), o programa será finalizado.");
    Console.WriteLine("Pressione ENTER para confirmar:");
    Thread.Sleep(3000);
    Environment.Exit(0);
}

// ====================================================================================================================================

// Entrada de Dados

string[] nomeProduto = new string[10];
float[] precoProduto = new float[10];
bool[] promocaoProduto = new bool[10];
string respostaContinuar = "";
int posicaoFinal = 0;

do{
    Console.Clear();
    posicaoFinal = MenuOpcoes(nomeProduto, precoProduto, promocaoProduto, posicaoFinal);
    respostaContinuar = VoltarMenu(respostaContinuar);
} while(respostaContinuar == "S");

FinalizaPrograma();

Console.WriteLine($"\nFim do Programa");

// Fim