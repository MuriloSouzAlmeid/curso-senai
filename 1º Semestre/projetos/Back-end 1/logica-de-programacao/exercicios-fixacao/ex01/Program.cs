// Poderá votar ou não

// Ler o ano atual e o ano de nascimento de uma pessoa. Escrever uma mensagem que diga se ela poderá ou não votar este ano (não é necessário considerar o mês em que a pessoa nasceu).

//Início
Console.WriteLine($"\nJá pode votar?\n");

// Entradas
var dataAtual = DateTime.Now;

Console.WriteLine($"Informe o ano em que você nasceu:");
int anoNascido = int.Parse(Console.ReadLine());

int idade = dataAtual.Year - anoNascido;

// Processamento e Saída

string respostaFinal = (idade < 16) ? $"\nSinto muito, mas você ainda não possui idade suficiente para votar.\n" : $"\nVocê já possui idade o suficiente para votar, vote com calma e sabedoria!\n";

Console.WriteLine(respostaFinal);

//Fim