// Qual número é maior

// Faça um programa que leia três números e mostre o maior e o menor deles.

// Início

Console.WriteLine(@$"Qual desses números é Maio e qual é Menor?");

// Entradas

float maiorNumero = 0f;
float menorNumero = 0f;
string respostaMaior = "";
string respostaMenor = "";

Console.WriteLine(@$"
Digite três números diferentes.
");


Console.WriteLine($"Qual o primeiro número?");
float n1 = float.Parse(Console.ReadLine());

Console.WriteLine($"Qual o segundo número?");
float n2 = float.Parse(Console.ReadLine());

Console.WriteLine($"Qual o primeiro número?");
float n3 = float.Parse(Console.ReadLine());

// Processamento

if((n1 > n2) && (n1 > n3)){
    maiorNumero = n1;
    respostaMaior = $"primeiro ({maiorNumero})";
} else if((n2 > n1) && (n2 > n3)){
    maiorNumero = n2;
    respostaMaior = $"segundo ({maiorNumero})";
} else if((n3 > n1) && (n3 > n2)){
    maiorNumero = n3;
    respostaMaior = $"terceiro ({maiorNumero})";
}

if((n1 < n2) && (n1 < n3)){
    menorNumero = n1;
    respostaMenor = $"primeiro ({menorNumero})";
} else if((n2 < n1) && (n2 < n3)){
    menorNumero = n3;
    respostaMenor = $"segundo ({menorNumero})";
} else if((n3 < n1) && (n3 < n2)){
    menorNumero = n3;
    respostaMenor = $"terceiro ({menorNumero})";
}

// Saída

if ((n1 == n2) && (n2 == n3)){
    Console.WriteLine(@$"
Os números informados são iguais, digite novamente.");
} else if(n1 == n2){
    Console.WriteLine(@$"
O primeiro e o segundo número são iguais, digite novamente.");
} else if(n2 == n3){
    Console.WriteLine(@$"
O segundo e o terceiro número são iguais, digite novamente.");
} else if(n1 == n3){
   Console.WriteLine(@$"
O primeiro e o terceiro número são iguais, digite novamente.");
} else{
    Console.WriteLine(@$"
O maior número digitado foi o {respostaMaior}, e o menor número digitado foi o {respostaMenor}.
");
}

// Fim

Console.WriteLine(@$"
Fim do Programa");
