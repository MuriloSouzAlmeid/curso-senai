using maquina_de_cafe;

MaquinaCafe TabajarasPlus = new MaquinaCafe();

string opcaoMenu = "";
string opcaoAcucar = "";
string escolhaFinal = "";

do{

        Console.Clear();
Console.WriteLine(@$"============================================================
|          Menu Super Cafeteira Tabajaras Plus++           |
|----------------------------------------------------------|");
if(TabajarasPlus.CafeDisponivel >= 1000){
    Console.WriteLine($"| Quantidade de Açúcar Disponível: {TabajarasPlus.CafeDisponivel}                     |");
    Console.WriteLine($"|----------------------------------------------------------|");
}else if(TabajarasPlus.CafeDisponivel >= 100){
    Console.WriteLine($"| Quantidade de Açúcar Disponível: {TabajarasPlus.CafeDisponivel}                    |");
    Console.WriteLine($"|----------------------------------------------------------|");
}else if(TabajarasPlus.CafeDisponivel >= 10){
    Console.WriteLine($"| Quantidade de Açúcar Disponível: {TabajarasPlus.CafeDisponivel}                   |");
    Console.WriteLine($"|----------------------------------------------------------|");
}
if(TabajarasPlus.CafeDisponivel < 10){
        Console.WriteLine($"| *Devido a falta de café só há a opção de café sem açúcar |");
    }
Console.WriteLine(@$"| [1] Café Sem Açúcar                                      |");
    if(TabajarasPlus.CafeDisponivel >= 10){
        Console.WriteLine($"| [2] Café Com Açúcar                                      |");
    }
Console.WriteLine(@$"| [0] Sair do Menu                                         |
============================================================");

Console.WriteLine($"\nSelecione a opção desejada:");
opcaoMenu = Console.ReadLine()!;

while((opcaoMenu != "1" && opcaoMenu != "2" && opcaoMenu != "0") || opcaoMenu == ""){
    Console.WriteLine($"Opção informada inválida, pressione ENTER para tentar novamente:");
    opcaoMenu = Console.ReadLine()!;
}

    switch(opcaoMenu){
        case "1":
            TabajarasPlus.FazerCafe(opcaoMenu);
            Console.WriteLine($"\nProntinho, café sem açúcar feito. Por favor retire o copo na bandeja abaixo.");
            break;

        case "2":
            Console.WriteLine($"\nComo deseja a inclusão do açúcar em seu café?");
            Console.WriteLine($"[1] -> Quantidade padrão de açúcar (10g)");
            Console.WriteLine($"[2] -> Quantidade específica de açúcar em gramas (informado pelo cliente)");
            Console.WriteLine($"[0] -> Voltar ao menu anterior");
            opcaoAcucar = Console.ReadLine()!;

            while(opcaoAcucar != "1" && opcaoAcucar != "2" && opcaoAcucar != "3"){
                Console.WriteLine($"\nOpção escolhida inválida. Escolha uma das opções presentes no menu acima.");
                opcaoAcucar = Console.ReadLine()!;
            }

                switch(opcaoAcucar){
                    case "1":
                        TabajarasPlus.FazerCafe(opcaoMenu);
                        Console.WriteLine($"\nProntinho, café com açúcar (10g) feito. Por favor retire o copo na bandeja abaixo.");
                        break;

                    case "2":
                        string escolhaFaltaAcucar = "";
                        bool cafeFeito = false;
                        do{
                            Console.WriteLine($"\nPois bem, informe a quantidade de acucar (em gramas) que deseja adicionar em seu café:");
                            float qtdAcucar = float.Parse(Console.ReadLine()!);

                            while(qtdAcucar <= 0){
                                Console.WriteLine($"\nQuantidade informada inválida, informe uma quantidade maior:");
                                qtdAcucar = float.Parse(Console.ReadLine()!);
                            }

                            if(qtdAcucar > TabajarasPlus.CafeDisponivel){
                                Console.WriteLine($"\nInfelizmente não possuímos tal quantidade disponível na máquina senhor. Por favor escolha entre:");
                                Console.WriteLine($"Deseja Informar uma nova quantidade? (s/n)");
                                escolhaFaltaAcucar = Console.ReadLine()!.ToLower();

                                while(escolhaFaltaAcucar != "s" && escolhaFaltaAcucar != "n"){
                                    Console.WriteLine($"\nOpção escolhida inválida. Escolha entre (s) para sim ou (n) para não:");
                                    escolhaFaltaAcucar = Console.ReadLine()!;
                                }
                            }
                            if(qtdAcucar <= TabajarasPlus.CafeDisponivel){
                                TabajarasPlus.FazerCafe(qtdAcucar);
                                Console.WriteLine($"\nProntinho, café com açúcar ({qtdAcucar}g) feito. Por favor retire o copo na bandeja abaixo."); 
                                cafeFeito = true; 
                            }
                        }while(escolhaFaltaAcucar == "s" && cafeFeito == false);
                        break;

                    case "0":
                        Console.WriteLine($"\nEntendido, pressione ENTER para voltar ao menu inicial:");
                        Console.ReadLine();
                        break;
                }
            break;

        case "0":
            Console.WriteLine($"\nObrigado por utilizar a Tabajaras Plus++. Pressione ENTER para desligar a máquina:");
            Console.ReadLine();
            Environment.Exit(0);
            break;
        }

Console.WriteLine($"\nObrigado por utilizar a Tabajaras Plus++. Por favor escolha entre:");
Console.WriteLine(@$"[1] Voltar ao menu inicial
[2] Desligar a Máquina");
escolhaFinal = Console.ReadLine()!;

while(escolhaFinal != "1" && escolhaFinal != "2"){
    Console.WriteLine($"\nOpção escolhida inválida. Por favor escolha entre as opções acima:");
    escolhaFinal = Console.ReadLine()!;
}

if(escolhaFinal == "2"){
    Console.WriteLine($"\nObrigado por utilizar a Tabajaras Plus++. Pressione ENTER para desligar a máquina:");
    Console.ReadLine();
    Environment.Exit(0); 
}

}while(escolhaFinal == "1");