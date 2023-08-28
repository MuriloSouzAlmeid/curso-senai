// Tabuada do 1 ao 10

// Escreva um algoritmo que imprima a tabuada (de 1 a 10) para os números de 1 a 10.

// Início

Console.WriteLine($"Programa de Tabuadas!");

int tabuada = 0;
int multiplicador = 0;
int resultado = 0;

for(tabuada = 1; tabuada <= 10; tabuada++){
    Console.WriteLine($"\nTabuada do {tabuada}:");
    for(multiplicador = 1; multiplicador <= 10; multiplicador ++){
        resultado = multiplicador * tabuada;
        Console.WriteLine($"{tabuada} x {multiplicador} = {resultado}");
    }
}

Console.WriteLine($"\nFim do Programa\n");
// Fim
