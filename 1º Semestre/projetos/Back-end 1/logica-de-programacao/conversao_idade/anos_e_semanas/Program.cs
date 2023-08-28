// Anos e Semanas

// Faça um programa que receba o ano do nascimento de uma pessoa e calcule a idade dessa pessoa em anos
// e semanas e imprima o resultado no console.

// Início

Console.WriteLine(@$"Há quanto tempo eu nasci?
");


// Entradas

var dataAtual = DateTime.Now;

Console.WriteLine($"Em qual ano você nasceu?");
int anoNascido = int.Parse(Console.ReadLine());


// Processamento

int idadeAnos = dataAtual.Year - anoNascido;
int idadeSemanas = idadeAnos * 52;

// Saída

Console.WriteLine(@$"
Atualmente você está vivo há aproximadamente {idadeAnos} anos, ou aproximadamente {idadeSemanas} semanas.");

// Fim