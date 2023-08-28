// Par ou Ímpar

// Início

Console.WriteLine($"\nPrograma para descobrir qual é par e qual é ímpar");

int[] numeros = new int[6];
int indice;
int resultadoDivisao;
int numerosPares = 0;
int numerosImpares = 0;
int numeros0 = 0;

for(indice = 0; indice < numeros.GetLength(0); indice++){
    Console.WriteLine($"\nDigite o {indice + 1}º número:");
    numeros[indice] = int.Parse(Console.ReadLine());
}

Console.WriteLine($"");

foreach(int item in numeros){
    resultadoDivisao = item % 2;
    if((resultadoDivisao == 0) && (item != 0)){
        Console.WriteLine($"O número {item} é par.");
        numerosPares++;
    } else if((resultadoDivisao != 0)){
        Console.WriteLine($"O número {item} é ímpar.");
        numerosImpares++;
    } else{
        Console.WriteLine($"O número {item} não se enquadra em par ou ímpar.");
        numeros0++;
    }
}

Console.WriteLine(@$"
A quantidade de números pares é: {numerosPares}.
A quantidade de números ímpares é: {numerosImpares}.
O núemro zero foi digitado {numeros0} vezes. 
");


// Fim