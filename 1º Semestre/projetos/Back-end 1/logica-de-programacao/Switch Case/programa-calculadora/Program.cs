// Programa Calculadora

// início

Console.WriteLine($"Programa de Calculadora.");

// entrada

Console.WriteLine(@$"
Informe a operação que será realizada:

(+) -> soma
(-) -> subtração
(x) -> multiplicação
(:) -> divisão
");
char operacao = char.Parse(Console.ReadLine());

Console.WriteLine(@$"
Informe o primeiro número da conta:");
double n1 = double.Parse(Console.ReadLine());

Console.WriteLine(@$"
Informe o segundo número da conta:");
double n2 = double.Parse(Console.ReadLine());

double resultado = 0;

// processamento

switch (operacao){
    case '+':
        resultado = n1 + n2;
        Console.WriteLine(@$"
O resultado da soma é igual à: {resultado}");
        break;

    case '-':
        resultado = n1 - n2;
        Console.WriteLine(@$"
O resultado da subtração é igual à: {resultado}");
        break;

    case 'x':
        resultado = n1 * n2;
        Console.WriteLine(@$"
O resultado da multiplicação é igual à: {resultado}");
        break;

    case ':':
        resultado = n1 / n2;
        Console.WriteLine(@$"
O resultado da divisão é igual à: {resultado}");
        break;
}

// Fim

Console.WriteLine(@$"
Fim do Cálculo");
