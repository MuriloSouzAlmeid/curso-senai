// See https://aka.ms/new-console-template for more information
Console.WriteLine("Digite um número");
float numeroDigitado = float.Parse(Console.ReadLine()!);

Console.WriteLine($"");
Console.WriteLine((numeroDigitado%2 == 0) ? "O número digitado é par" : "O número digitado é ímpar");