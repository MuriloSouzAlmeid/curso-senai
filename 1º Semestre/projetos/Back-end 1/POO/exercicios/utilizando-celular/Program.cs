using utilizando_celular;
using utilizando_celular.operacoes_gerais;

// Início
string[] simOuNao = new string[2] {"s", "n"};

Celular celular = new Celular();
Finalizador finalizaPrograma = new Finalizador();
Verificador verificaResposta = new Verificador();
Menu menuOpcoes = new Menu();

Console.Clear();

Console.WriteLine($"\nPrograma de simulação de um Celular");

Console.WriteLine($"\nDigite o Modelo do celular:");
celular.Modelo = Console.ReadLine()!;

Console.WriteLine($"\nDigite a cor do celular:");
celular.Cor = Console.ReadLine()!;

Console.WriteLine($"\nDigite o tamanho da tela do celular em polegadas:");
celular.Tamanho = Console.ReadLine()!;



do{
    if(celular.Ligado == false){
        Console.WriteLine(celular.MostaStatus());
    }
    
    if(celular.Ligado == false){
        Console.WriteLine($"\nDeseja Ligar o Celular? (s/n)");
        string respostaLigar = Console.ReadLine()!.ToLower();
        respostaLigar = verificaResposta.VerificarResposta(respostaLigar, simOuNao);

        Console.WriteLine((respostaLigar == "s") ? celular.Ligar() : finalizaPrograma.FinalizarPrograma());
    } 

    Console.WriteLine($"\nPressione ENTER para ser redirecionado ao menu de ações:");
    Console.ReadLine();

    do{
        Console.Clear();
        menuOpcoes.MostrarMenuOpcoes(celular, verificaResposta);
    } while(celular.Ligado);

    if(celular.Ligado == false){
        Console.WriteLine($"\nPretende continuar usando o celular? (s/n)");
        string respostaUtilizar = Console.ReadLine()!.ToLower();
        respostaUtilizar = verificaResposta.VerificarResposta(respostaUtilizar, simOuNao);

        Console.WriteLine((respostaUtilizar == "s") ? celular.Ligar() : finalizaPrograma.FinalizarPrograma());
        
    }
    
} while(celular.Ligado || celular.Ligado == false);

// Fim