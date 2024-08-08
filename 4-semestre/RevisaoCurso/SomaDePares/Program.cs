// See https://aka.ms/new-console-template for more information

int soma = 0;
int cont = 0;

while (cont <= 100){
    soma += (cont%2 == 0) ? cont : 0;
    cont++;
}

Console.WriteLine($"A soma dos pares de 1 à 100 é: {soma}");