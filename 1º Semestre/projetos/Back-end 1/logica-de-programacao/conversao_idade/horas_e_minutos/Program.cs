// Meses Dias Horas e Minutos

// Faça um programa que receba a idade de uma pessoa e calcule a idade em meses, dias, horas e minutos.
// Imprima o resultado no console.

// Início

Console.WriteLine(@$"Há Quanto Tempo Eu Nasci?
");

// Entradas

var dataAtual = DateTime.Now;

Console.WriteLine(@$"Quantos anos você tem? ");
int idade = int.Parse(Console.ReadLine());

// Processamento

var idadeMeses = idade * 12;
var idadeDias = idade * 365;
var idadeHoras = idadeDias * 24;
var idadeMinutos = idadeHoras * 60;

// Saída

Console.WriteLine(@$"
Já faz {idade} anos que você nasceu, {idadeMeses} meses, {idadeDias} dias, aproximadamente {idadeHoras} horas e aproximadamente {idadeMinutos} minutos.
");

// Fim