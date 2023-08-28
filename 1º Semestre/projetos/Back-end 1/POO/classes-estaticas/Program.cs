using classes_estaticas;
using System.Globalization;

float dolarAtual = 4.99f;
float resultado;
string opcaoMenu = "";

do{
    Console.Clear();
    Console.WriteLine($"============================================");
    Console.WriteLine($"|           Conversão De Valores           |");
    Console.WriteLine($"|------------------------------------------|");
    Console.WriteLine($"| Valor atual do Dólar em Relação ao Real: |");
    Console.WriteLine($"| {dolarAtual:C2}                                  |");
    Console.WriteLine($"|                                          |");
    Console.WriteLine($"| [1] Real Para Dólar                      |");
    Console.WriteLine($"| [2] Dólar Para Real                      |");
    Console.WriteLine($"| [0] Sair do Programa                     |");
    Console.WriteLine($"============================================");

    Console.WriteLine($"\nEscolha entre as opções acima:");
    opcaoMenu = Console.ReadLine()!;

    float quantia;

    switch(opcaoMenu){
        case "1":
            Console.WriteLine($"\nInforme a quantia a ser convertida:");
            quantia = float.Parse(Console.ReadLine()!);
            resultado = ConversaoMoeda.RealParaDolar(quantia);
            Console.WriteLine($"\nO valor informado convertido para o dólar resulta em aproximadamente: {resultado.ToString("C", new CultureInfo("en-US"))}");
            break;

        case "2":
            Console.WriteLine($"\nInforme a quantia a ser convertida:");
            quantia = float.Parse(Console.ReadLine()!);
            resultado = ConversaoMoeda.DolarParaReal(quantia);
            Console.WriteLine($"\nO valor informado convertido para o real resulta em aproximadamente: {resultado:C2}");
            break;

        case "0":
            Console.WriteLine($"\nPressione ENTER para finalizar o programa:");
            Console.ReadLine();
            Environment.Exit(0);
            break;
        
        default:
            Console.WriteLine($"\nOpção informada inválida");
            break;
    }

    Console.WriteLine($"\nPressione ENTER para voltar ao menu de conversão:");
    Console.ReadLine();
}while(opcaoMenu != "0");