// Tabuada

// Faça um programa que receba um número inteiro e mostre a sua tabuada.

// Início

Console.WriteLine(@$"
==================
|    Tabuada     |
==================
");

Console.WriteLine($"Digite um número para se tirar sua tabuada:");
int num = int.Parse(Console.ReadLine());

int resultado = 0;

for(int multiplicador = 0; multiplicador <= 10; multiplicador++){
    resultado = num * multiplicador;
    Console.WriteLine($"{num} x {multiplicador} = {num * multiplicador}");
}

Console.WriteLine($"\nFim da Tabuada.");

// Fim
