// Desafio Algorítmo Fibonacci

//  Pesquise como funciona o algoritmo Fibonacci e faça um programa que gere a série até que o valor seja maior que 500. 

// Início

Console.WriteLine($"Algorismo Fibonacci até o valor 500:");

int valorAtual = 1;
int valorAnterior = 0;
int valorSomado = 0;

Console.WriteLine($"0");
while(valorAtual <= 500){
    Console.WriteLine($"{valorAtual}");
    valorSomado = valorAnterior;
    valorAnterior = valorAtual;
    valorAtual = valorAtual + valorSomado;
}

// Fim