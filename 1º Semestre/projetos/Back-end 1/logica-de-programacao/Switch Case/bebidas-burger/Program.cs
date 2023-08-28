// Crdápio de Bebidas Burger King

//Início

Console.WriteLine(@$"Cardápio de bebidas do Burger King
");

// Entradas

Console.WriteLine(@$"
Escolha a bebida a ser servida:

[1] Coca Cola
[2] Fanta
[3] Sprite
[4] Guaraná
[5] Chá Gelado
");
int escolhaBebida = int.Parse(Console.ReadLine());

string escolhaGelo = String.Empty;

// Processamento e Saída

switch(escolhaBebida){
    case 1:
        Console.WriteLine(@$"
Gostaria de adicionar gelo em sua Coca Cola? (s/n)");
        escolhaGelo = Console.ReadLine().ToUpper();
        switch(escolhaGelo){
                case "S":
                        Console.WriteLine(@$"
Pois bem senhor, sua Coca Cola será servida com gelo, aproveite!");
                        break;

                case "N":
                        Console.WriteLine(@$"
Pois bem senhor, sua Coca Cola será servida sem gelo, aproveite!");
                        break;
                
                default:
                        Console.WriteLine(@$"
Opção escolhida inválida, recomece o pedido!");
                        break;
        }
        break;

        case 2:
        Console.WriteLine(@$"
Gostaria de adicionar gelo em sua Fanta? (s/n)");
        escolhaGelo = Console.ReadLine().ToUpper();
        if(escolhaGelo == "S"){
            Console.WriteLine(@$"
Pois bem senhor, sua Fanta será servida com gelo, aproveite!");
        } else if(escolhaGelo == "N"){
            Console.WriteLine(@$"
Pois bem senhor, sua Fanta será servida sem gelo, aproveite!");
        } else{
            Console.WriteLine(@$"
Opção escolhida inválida, recomece o pedido!");
        }
        break;

        case 3:
        Console.WriteLine(@$"
Gostaria de adicionar gelo em sua Sprite? (s/n)");
        escolhaGelo = Console.ReadLine().ToUpper();
        if(escolhaGelo == "S"){
            Console.WriteLine(@$"
Pois bem senhor, sua Sprite será servida com gelo, aproveite!");
        } else if(escolhaGelo == "N"){
            Console.WriteLine(@$"
Pois bem senhor, sua Sprite será servida sem gelo, aproveite!");
        } else{
            Console.WriteLine(@$"
Opção escolhida inválida, recomece o pedido!");
        }
        break;

        case 4:
        Console.WriteLine(@$"
Gostaria de adicionar gelo em seu Guaraná? (s/n)");
        escolhaGelo = Console.ReadLine().ToUpper();
        if(escolhaGelo == "S"){
            Console.WriteLine(@$"
Pois bem senhor, seu Guaraná será servida com gelo, aproveite!");
        } else if(escolhaGelo == "N"){
            Console.WriteLine(@$"
Pois bem senhor, seu Guaraná será servida sem gelo, aproveite!");
        } else{
            Console.WriteLine(@$"
Opção escolhida inválida, recomece o pedido!");
        }
        break;

        case 5:
        Console.WriteLine(@$"
Gostaria de adicionar gelo em seu Chá Gelado? (s/n)");
        escolhaGelo = Console.ReadLine().ToUpper();
        if(escolhaGelo == "S"){
            Console.WriteLine(@$"
Pois bem senhor, seu Chá Gelado será servida com gelo, aproveite!");
        } else if(escolhaGelo == "N"){
            Console.WriteLine(@$"
Pois bem senhor, seu Chá Gelado será servida sem gelo, aproveite!");
        } else{
            Console.WriteLine(@$"
Opção escolhida inválida, recomece o pedido!");
        }
        break;

        default:
            Console.WriteLine(@$"
Digite uma opção válida.");
        break;
            
}

// Fim
Console.WriteLine(@$"
Fim do Programa");