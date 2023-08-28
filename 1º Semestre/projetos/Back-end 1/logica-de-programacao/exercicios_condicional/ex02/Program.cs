// Time Vencedor

// Desenvolva um programa que recebe do usuário, o placar de um jogo de futebol (os gols de cada time) e informa se o resultado foi um empate, se a vitória foi do primeiro time ou do segundo time.

// Início

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine(@$"
======================================================================
                       Programa De Placar De Gols
======================================================================
");
Console.ResetColor();

// Entradas

Console.WriteLine($"Informe quantos gols o Primeiro time fez durante a partida: ");
int golsPrimeiro = int.Parse(Console.ReadLine());

Console.WriteLine($"Informe quantos gols o Segundo time fez durante a partida: ");
int golsSegundo = int.Parse(Console.ReadLine());

// Processamento

if (golsPrimeiro > golsSegundo){
    Console.ForegroundColor = ConsoleColor.Blue;

    // Saída
    Console.WriteLine(@$"
O Primeiro Time ganhou a partida!!
Com o placar de {golsPrimeiro} x {golsSegundo}");

    Console.ResetColor();
} else if (golsPrimeiro == golsSegundo){
    Console.ForegroundColor = ConsoleColor.Yellow;

    // Saída
    Console.WriteLine(@$"
A Partida terminou em Empate!
Com o placar de {golsPrimeiro} x {golsSegundo}");
    Console.ResetColor();
} else{
    Console.ForegroundColor = ConsoleColor.Red;

    // Saída
    Console.WriteLine(@$"
O Segundo Time ganhou a partida!!
Com o placar de {golsPrimeiro} x {golsSegundo}");
    Console.ResetColor();

}

// Fim

Console.WriteLine(@$"
========================================================================
                            Fim do Programa
========================================================================
");