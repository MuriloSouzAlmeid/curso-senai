// Dobro de 5 Números

// Início

Console.WriteLine($"\nPrograma de Dobro de Números\n");

int[] numeros = new int[5];
int indice;

for(indice = 0; indice <= 4; indice++){
    Console.WriteLine($"\nDigite o {indice + 1}º número:");
    numeros[indice] = int.Parse(Console.ReadLine());
}

indice = 0;

foreach(int numero in numeros){
    Console.WriteLine($"\nO dobro do {indice + 1}º é: {numero * 2}\n");
}

// Fim