// Cadastro do viagens

// Início

Console.Clear();

// Funções ========================================================================================================================

static string[] CriarCadastro(){
    string[] cadastroUsuario = new string[2];
    Console.WriteLine($"\nPágina de cadastro de novos usuário.\n");
    
    Console.WriteLine($"Informe o nome de usuário a ser cadastrado:");
    string nomeUsuario = Console.ReadLine()!.ToUpper();
        
    Console.WriteLine($"Informe a senha de usuário a ser cadastrada:");
    string senhaUsuario = Console.ReadLine()!.ToUpper();
    while(senhaUsuario.Contains(nomeUsuario)){
        Console.WriteLine($"Por segurança sua senha de usuário não pode conter seu nome de usuário, digite uma senha mais forte:");
        senhaUsuario = Console.ReadLine()!.ToUpper();
    }
    cadastroUsuario[0] = nomeUsuario;
    cadastroUsuario[1] = senhaUsuario;

    return cadastroUsuario;
}

// -------------------------------------------------------------------------------------------------------------------

static bool EfetuarLogin(string nomeCadastro, string senhaCadastro, string nomeLogin, string senhaLogin){
    bool loginCorreto;
    if((nomeCadastro != nomeLogin) || (senhaCadastro != senhaLogin)){
        loginCorreto = false;
    } else{
        loginCorreto = true;
    }

    return loginCorreto;
}

// --------------------------------------------------------------------------------------------------

static int MenuOpcoes(string[] nomePassageiro, string[] origemViagem, string[] destinoViagem, string[] dataViagem, string[] horarioViagem, int posicaoFinal){
    Console.Clear();
    string continuar = "s";
    int posicao = posicaoFinal; 
    string respostaMenu;
    Console.WriteLine($"Menu de opções");
    Console.WriteLine($"Escolha dentre uma das opções abaixo para realizar em nosso site:");
    Console.WriteLine(@$"(1) -> Cadastrar uma viagem no perfil do usuário.
(2) -> Lista de viagens cadastradas pelo usuário
(0) -> Sair do Programa");
    respostaMenu = Console.ReadLine()!.ToUpper();

    while((respostaMenu != "1") && (respostaMenu != "2") && (respostaMenu != "0")){
        Console.WriteLine($"Opção selecionada inválida. Escolha entre (1) para cadastrar uma nova viagem, (2) para ver a lista de viagens cadastradas ou (0) para sair so programa:");
        respostaMenu = Console.ReadLine()!;
    }

    switch(respostaMenu){
        case "1":
            Console.Clear();
            do{
                if(posicao == 5){
                    Console.WriteLine($"\nNúmero máximo de cadastro de viagens simultâneas por usuário atingido\n!");
                } else{
                    CadastrarViagem(nomePassageiro, origemViagem, destinoViagem, dataViagem, horarioViagem, posicao);
                    Console.WriteLine($"\nDeseja cadastrar mais uma viagem?");
                    continuar = Console.ReadLine()!.ToUpper();
                    posicao++;
                }
                
            }while((continuar == "S") && (posicao < 5));
        break;

        case "2":
            ListarViagens(nomePassageiro, origemViagem, destinoViagem, dataViagem, horarioViagem, posicao);
            break;

        case "0":
            Console.WriteLine($"\nOk, o programa será finalizado. Pressione ENTER para continuar.");
            Console.ReadLine();
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine($"Algo está errado.");
            break;
    }

    return posicao;
}

// -------------------------------------------------------------------------------------------------------------

static void CadastrarViagem(string[] nome, string[] origem, string[] destino, string[] data, string[] horario, int posicao){
    Console.WriteLine($"\nCadastro de Viagens");
    Console.WriteLine($"\nInforme o nome do passageiro que realizará a viagem:");
    nome[posicao] = Console.ReadLine()!;

    Console.WriteLine($"\nInforme o local de origem da viagem:");
    origem[posicao] = Console.ReadLine()!;

    Console.WriteLine($"\nInforme o local de destino da viagem:");
    destino[posicao] = Console.ReadLine()!;

    Console.WriteLine($"\nInforme a data da viagem (no formato dd/mm/aaaa):");
    data[posicao] = Console.ReadLine()!;

    Console.WriteLine($"\nInforme o horario da viagem (em formato hr:mn):");
    horario[posicao] = Console.ReadLine()!;
}

// ---------------------------------------------------------------------------------------------------

static void ListarViagens(string[] nome, string[] origem, string[] destino, string[] data, string[] horario, int posicao){
    Console.Clear();
    Console.WriteLine($"\nViagens Cadastradas no perfil do usuário");
Console.WriteLine(@$"
----------------------------------------------------------
| Nome do Passageiro | Origem | Destino | Data | Horário |");

    for(int indice = 0; indice < posicao; indice++){
        Console.WriteLine(@$"----------------------------------------------------------
| {nome[indice]}   |   {origem[indice]} | {destino[indice]} | {data[indice]} | {horario[indice]} |
----------------------------------------------------------");
    }
}

// ====================================================================================================================================

string[] nomePassageiro = new string[5];
string[] origemViagem = new string[5];
string[] destinoViagem = new string[5];
string[] dataViagem = new string[5];
string[] horarioViagem = new string[5];
int posicaoFinal = 0;

Console.WriteLine($"\nBem vindo ao site Viage Bem. Deseja cadastrar um novo usuário em nosso site? (s/n)");
string respostaCadastro = Console.ReadLine()!.ToLower();

while(((respostaCadastro != "s") && (respostaCadastro != "n")) || (respostaCadastro == "")){
    Console.WriteLine($"\nOpção escolhida inválida.");
    Console.WriteLine($"Escolha entre (s) para sim e (n) para não:");
    respostaCadastro = Console.ReadLine()!.ToLower();
}

string[] cadastro = new string[2];

switch(respostaCadastro){
    case "s":
        Console.Clear();
        cadastro = CriarCadastro(); 
        Console.WriteLine($"\nCadastro realizado com sucesso! Agora o(a) senhor(a) será direcionado(a) para a página de login em nosso site.");
        Console.WriteLine($"Pressione ENTER para continuar");
        Console.ReadLine();
        break;

    case "n":
        Console.WriteLine($"Ok senhor(a). O programa irá ser finalizado agora, pressione ENTER para confirmar.");
        Console.ReadLine();
        Environment.Exit(0);
        break;
}

Console.Clear();
Console.WriteLine($"Página de login de usuário\n");

Console.WriteLine($"Informe aqui seu nome de usuário cadastrado:");
string nomeLogin = Console.ReadLine()!.ToUpper();


Console.WriteLine($"Informe aqui sua senha de usuário cadastrada:");
string senhaLogin = Console.ReadLine()!.ToUpper();

bool loginValido = EfetuarLogin(cadastro[0], cadastro[1], nomeLogin, senhaLogin);

switch(loginValido){
    case true:
        Console.WriteLine($"\nLogin efetuado com sucesso! Bem vindo ao nosso site {nomeLogin}.");
        Console.WriteLine($"Agora você está prestes a ser redirecionado ao nosso menu de ações. Pressione ENTER para continuar:");
        Console.ReadLine();
        break;
    
    case false:
        int chances = 4;
        while((chances > 0) && (loginValido == false)){
            Console.WriteLine($"\nUsuário ou senha incorreto, digite novamente\n");
            Console.WriteLine($"Informe aqui seu nome de usuário cadastrado:");
            nomeLogin = Console.ReadLine()!.ToUpper();

            Console.WriteLine($"\nInforme aqui sua senha de usuário cadastrada:");
            senhaLogin = Console.ReadLine()!.ToUpper();
            loginValido = EfetuarLogin(cadastro[0], cadastro[1], nomeLogin, senhaLogin);
            chances--;
        }

        switch(loginValido){
            case true:
                Console.WriteLine($"\nLogin efetuado com sucesso! Bem vindo ao nosso site {nomeLogin}.");
                Console.WriteLine($"Agora você está prestes a ser redirecionado ao nosso menu de ações. Pressione ENTER para continuar:");
                Console.ReadLine();
                break;

            case false:
                Console.WriteLine($"Acabaram suas tentativas de login, tente novamente mais tarde.");
                Environment.Exit(0);
                break;
        }
        break;
}

string opcaoMenu;
do{
    posicaoFinal = MenuOpcoes(nomePassageiro, origemViagem, destinoViagem, dataViagem, horarioViagem, posicaoFinal);
    Console.WriteLine($"Deseja retornar para o menu inicial? (s/n)");
    opcaoMenu = Console.ReadLine()!.ToUpper();
    if(opcaoMenu != "S"){
        Console.WriteLine($"Ok senhor(a). O programa irá ser finalizado agora, pressione ENTER para confirmar.");
        Console.ReadLine();
        Environment.Exit(0);
    }
}while(opcaoMenu == "S");
// Fim