// Qual o Triângulo?

// Escreva     um     programa que leia     as     medidas     dos     lados     de     um     triângulo     e    escreva    se    ele    é    Equilátero,    Isósceles    ou  Escaleno. 
// Sendo    que:    
// − Triângulo    Equilátero:    possui    os    3    lados    iguais.
// − Triângulo    Isóscele:    possui    2    lados    iguais.
// − Triângulo    Escaleno:    possui    3    lados    diferentes.

// Início
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine(@$"
===============================================================
                    Qual o tipo do triângulo?
===============================================================
");
Console.ResetColor();

// Entrada
Console.WriteLine($"Digite a medida do primeiro lado do triângulo:");
float primeiroLado = float.Parse(Console.ReadLine());

Console.WriteLine($"Digite a medida do segundo lado do triângulo:");
float segundoLado = float.Parse(Console.ReadLine());

Console.WriteLine($"Digite a medida do terceiro lado do triângulo:");
float terceiroLado = float.Parse(Console.ReadLine());
// Processamento

if((primeiroLado == segundoLado) && (primeiroLado == terceiroLado) && (segundoLado == terceiroLado)){
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    // Saída
    Console.WriteLine(@$"
Esse é um triângulo Equilátero");
Console.ResetColor();
} else if ((primeiroLado != segundoLado) && (primeiroLado != terceiroLado) && (segundoLado != terceiroLado)){
    Console.ForegroundColor = ConsoleColor.Red;
    // Saída
    Console.WriteLine(@$"
Esse é um triângulo Escaleno");
Console.ResetColor();
} else{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    // Saída
    Console.WriteLine(@$"
Esse é um Triângulo Isóceles");
Console.ResetColor();
}

// Fim
Console.WriteLine(@$"
========================================================================
                           Fim do Programa
========================================================================
");
