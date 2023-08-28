// Os últimos serão os primeiros

// Faça um algoritmo para ler 15 números e armazenar em um vetor. Após a leitura total dos
// 15 números, o algoritmo deve escrever esses 15 números lidos na ordem inversa da qual foi
// declarado.

// Início

Console.WriteLine($"\nOs Últimos Serão Os primeiros");

// Entrada

float[] numerosDigitados = new float[15];
int indice;

for(indice = 0; indice < numerosDigitados.GetLength(0); indice++){
    Console.WriteLine($"\nDigite o {indice + 1}º número:");
    numerosDigitados[indice] = float.Parse(Console.ReadLine());
}

// Processamento e Saída
Console.WriteLine("\nPega o REVERSE!\n");
for(indice = numerosDigitados.GetLength(0) - 1; indice >= 0; indice--){
    Console.WriteLine($"{numerosDigitados[indice]}");
}

Console.WriteLine();

// Fim