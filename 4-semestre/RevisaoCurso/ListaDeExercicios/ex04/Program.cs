// See https://aka.ms/new-console-template for more information
static float[] GerarTabuada(float numero){
    float[] arrayTabuada = new float[10];

    for(int i = 0; i < 10; i++){
        arrayTabuada[i] = numero * (i+1);
    }

    return arrayTabuada;
}

Console.WriteLine($"Informe o núemro a ser gerada a tabuada:");
float numeroDigitado = float.Parse(Console.ReadLine()!);

float[] tabuada = GerarTabuada(numeroDigitado);

Console.WriteLine($"Tabuada do núemero {numeroDigitado}");
for(int index = 0; index < tabuada.Length; index++){
    Console.WriteLine($"{numeroDigitado} x {index+1}: {tabuada[index]}");
}