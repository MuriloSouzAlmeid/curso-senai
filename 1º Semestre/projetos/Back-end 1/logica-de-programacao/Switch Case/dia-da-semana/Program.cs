// Programa Dia da Semana

// Início

Console.WriteLine(@$"
Qual dia da semana é hoje
");

// Entrada

Console.WriteLine($"Digite o número do dia da semana que você está (de 1 a 7 - Domingo a Sábado)");
int diaSemana = int.Parse(Console.ReadLine());

// Processamento

switch (diaSemana){
    case 1:
        Console.WriteLine(@$"
        Hoje é Domingo!");
        break;

    case 2:
        Console.WriteLine(@$"
        Hoje é Segunda-Feira");
        break;

    case 3:
        Console.WriteLine(@$"
        Hoje é Terça-Feira");
        break;

    case 4:
        Console.WriteLine(@$"
        Hoje é Quarta-Feira");
        break;

    case 5:
        Console.WriteLine(@$"
        Hoje é Quinta-Feira");
        break;

    case 6:
        Console.WriteLine(@$"
        Hoje é Sexta-Feira");
        break;

    case 7:
        Console.WriteLine(@$"
        Hoje é Sábado");
        break;

    default:
        Console.WriteLine(@$"
        Número digitado inválido, digite um número de 1 a 7!");
        break;
}

// Fim

Console.WriteLine(@$"
Fim do Programa");
