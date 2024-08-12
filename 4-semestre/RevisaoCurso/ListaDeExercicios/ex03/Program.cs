// See https://aka.ms/new-console-template for more information
Console.WriteLine($"Digite 10 números em uma linha separados por caracteres vazios:");
string numerosEmLinha = Console.ReadLine()!;

string[] arrayNumerosString = numerosEmLinha.Split(" ");
float[] arrayNumeros = new float[10];

for(int index = 0; index < 10; index++){
    arrayNumeros[index] = float.Parse(arrayNumerosString[index]);
}

float somatoria = 0;

for(int i = 0; i < arrayNumeros.Length; i++){
    somatoria += arrayNumeros[i];
}

Console.WriteLine($"A somatória dos números pares é: {somatoria}");
