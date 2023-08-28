// Calcula Média

// Faça um programa que receba 5 notas de um aluno e calcula a média aritmétrica. Imprimir a resposta no console

// Início

Console.ForegroundColor = ConsoleColor.Blue;

Console.WriteLine(@$"
------------------------------------
        | Cálculo de Média |
------------------------------------
");
Console.ResetColor();

// Entradas

Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine($"Informe Sua Primeira Nota: ");
float n1 = float.Parse(Console.ReadLine());

Console.WriteLine(@$"
Informe Sua Segunda Nota: ");
float n2 = float.Parse(Console.ReadLine());

Console.WriteLine(@$"
Informe Sua Terceira Nota: ");
float n3 = float.Parse(Console.ReadLine());

Console.WriteLine(@$"
Informe Sua Quarta Nota: ");
float n4 = float.Parse(Console.ReadLine());

Console.WriteLine(@$"
Informe Sua Quinta Nota: ");
float n5 = float.Parse(Console.ReadLine());
Console.ResetColor();

// Processamento

float media = (n1 + n2 + n3 + n4 + n5) / 5;

// Saída

Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine(@$"
A média de suas notas é {Math.Round(media,1)}");

Console.ResetColor();

// Fim