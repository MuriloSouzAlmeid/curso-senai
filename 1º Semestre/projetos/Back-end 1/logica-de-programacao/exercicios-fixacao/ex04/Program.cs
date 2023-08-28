// Maior e menor

// Faça um programa que leia 10 valores digitados pelo usuário e no final, escreva o maior e o menor valor lido.

// Início

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\nQual é o Maior e qual é o Menor?");
Console.ResetColor();

// Entradas

float[] numerosDigitados = new float[10];

Console.ForegroundColor = ConsoleColor.Cyan;
for(int indice = 0; indice < 10; indice++){
    Console.WriteLine($"\nDigite o {indice + 1}º número a ser comparado:");
    numerosDigitados[indice] = float.Parse(Console.ReadLine());
}
Console.ResetColor();

// Processamento

static float CalculaMaiorNumero(float[] numerosDigitados){
    float maior = 0;
    foreach(float numero in numerosDigitados){
        if(numero > maior){
            maior = numero;
        }
    }
    return maior;
}

float maiorNumero = CalculaMaiorNumero(numerosDigitados);

static float CalculaMenorNumero(float[] numerosDigitados, float maiorNumero){
    float menor = maiorNumero;
    foreach(float numero in numerosDigitados){
        if(numero < menor){
            menor = numero;
        }
    }
    return menor;
}

float menorNumero = CalculaMenorNumero(numerosDigitados, maiorNumero);

// saída

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"\nDentre os números digitados o maior é o {maiorNumero} e o menor é o {menorNumero}\n");
Console.ResetColor();

// Fim