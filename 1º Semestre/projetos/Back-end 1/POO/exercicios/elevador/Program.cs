using elevador;

// Funções ------------------

static int VerificarDados(string dado){
    while(dado == ""){
        Console.WriteLine($"Entrada informada inválida. Informe-a novamente:");
        dado = Console.ReadLine()!;
    }
    int dadoResultante = int.Parse(dado);
    return dadoResultante;
}

// --------------------------

string confirmarDados = "";
int andares = 0;
int capacidade = 0;
string opcaoAcao = "";
Elevador Elevador = new Elevador();

Console.Clear();
Console.WriteLine(@$"
====================================================
|               Programa de Elevador               |
====================================================");

do{
    Console.WriteLine($"\nInforme quantos andares possui o prédio em questão: (desconsiderando o térreo)");
    string andaresInformados = Console.ReadLine()!;
    andares = VerificarDados(andaresInformados);

    Console.WriteLine($"\nInforme qual a quantidade de pessoas que cabem no elevador");
    string capacidadeInformada = Console.ReadLine()!;
    capacidade = VerificarDados(capacidadeInformada);

    Console.WriteLine($"\nA capacidade do elevador é {capacidade} pessoas e o prédio tem {andares} andares");
    Console.WriteLine($"Confirma tais informações? (s/n)");
    confirmarDados = Console.ReadLine()!.ToLower();

    while(confirmarDados != "s" && confirmarDados != "n"){
        Console.WriteLine($"\nOpção selecionada inválida, escolha entre (s) para sim ou (n) para não:");
        confirmarDados = Console.ReadLine()!.ToLower();
    }

    if(confirmarDados == "s"){
        Console.WriteLine($"\nPressione ENTER para iniciar o elevador:");
        Console.Read();
    }else{
        Console.WriteLine($"\nPressione ENTER para retornar às definições do elevador:");
        Console.Read();
    }
}while(confirmarDados == "n");


Elevador.Iniciar(andares, capacidade);

do{
    Console.Clear();
    Console.WriteLine(@$"=========================================
|             Menu Elevador             |
|---------------------------------------|");
    if(Elevador.AndarAtual == 0){
        Console.WriteLine($"| Andar Atual: Térreo                   |");
    }else if(Elevador.AndarAtual == Elevador.TotalAndar){
        Console.WriteLine($"| Andar Atual: Último andar             |");
    }else if(Elevador.TotalAndar < 10){
        Console.WriteLine($"| Andar Atual: {Elevador.AndarAtual}º                       |");
    }else{
        Console.WriteLine($"| Andar Atual: {Elevador.AndarAtual}º                      |");
    }

    if(Elevador.PessoasPresentes == 0){
        Console.WriteLine($"| O elevador está vazio                 |");
    }else if(Elevador.PessoasPresentes >= 10){
        Console.WriteLine($"| Quantidade de pessoas no elevador: {Elevador.PessoasPresentes} |");
    }else if(Elevador.PessoasPresentes == Elevador.CapacidadeElevador){
        Console.WriteLine($"| O elevador está cheio                 |");
    }else{
        Console.WriteLine($"| Quantidade de pessoas no elevador: {Elevador.PessoasPresentes}  |");
    }

    Console.WriteLine(@$"|---------------------------------------|
|             Ações Possíveis           |
|---------------------------------------|
| [1] -> Subir Andares                  |
| [2] -> Descer Andares                 |
| [3] -> Entrar Pessoas                 |
| [4] -> Sair   Pessoas                 |
| [0] -> Finalizar Programa             |
=========================================");

    Console.WriteLine($"\nInforme a ação que deseja tomar:");
    opcaoAcao = Console.ReadLine()!; 

    do{
        if((opcaoAcao != "1" && opcaoAcao != "2" && opcaoAcao != "3" && opcaoAcao != "4" && opcaoAcao != "0") ||opcaoAcao == ""){
            Console.WriteLine($"\nEntrada informada inválida. Informe-a novamente:");
            opcaoAcao = Console.ReadLine()!;
        }
    }while((opcaoAcao != "1" && opcaoAcao != "2" && opcaoAcao != "3" && opcaoAcao != "4" && opcaoAcao != "0") ||opcaoAcao == "");

    switch(opcaoAcao){
        // Subir andares
        case "1":
            Elevador.Subir();
            break;

        // Descer Andares
        case "2":
            Elevador.Descer();
            break;

        // Entrar Pessoas
        case "3":
            Elevador.Entar();
            break;

        // Sair Pessoas
        case "4":
            Elevador.Sair();
            break;

        // Finalizar Programa
        case "0":
            Console.WriteLine($"\nO programa será encerrado agora. Pressione ENTER para continuar:");
            Console.ReadLine();
            Environment.Exit(0);
            break;

        // Opção Inválida
        default:
            Console.WriteLine($"\nOpção informada inválida!");
            Console.WriteLine($"\nPressione ENTER para voltar ao menu:");
            Console.ReadLine();
            break;
    }

}while(opcaoAcao != "0");