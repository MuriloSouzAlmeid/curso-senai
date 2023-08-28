// Tabuada das Tabuadas

// Escreva um algoritmo que imprima a tabuada (de 1 a 10) para os números de 1 a 10. Exemplo: tabuada do 1, tabuada do 2, etc... Dica: utilize um laço dentro do outro.

// Início

Console.WriteLine($"\nTabuada das Tabuadas");

// Entradas

int tabuada;
int multiplicador;
int resultado;

// Processamento

for(tabuada = 1; tabuada <= 10; tabuada++){
    Console.WriteLine($"\nTabuada do {tabuada}:");
    for(multiplicador = 1; multiplicador <= 10; multiplicador++){
        resultado = multiplicador * tabuada;
        Console.WriteLine($"{tabuada} x {multiplicador} = {resultado}");
    }
}

Console.WriteLine();
// Fim