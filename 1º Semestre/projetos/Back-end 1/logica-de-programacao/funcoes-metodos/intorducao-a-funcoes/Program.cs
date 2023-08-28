// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         Console.WriteLine("Hello, World!");
//     }
// }

Console.WriteLine($"\nCalculadora por meio de Métodos");


static double OperacaoSoma(double n1, double n2){
    return n1 + n2;
}

static double OperacaoSubtracao(double n1, double n2){
    return n1 - n2;
}

static double OperacaoMultiplicacao(double n1, double n2){
    return n1 * n2;
}

static double OperacaoDivisao(double n1, double n2){
    return n1 / n2;
}

double[] numeros = new double[2];

double resultado = 0;

string operacaoRealizada = "";

for(int contador = 0; contador < 2; contador++){
    Console.WriteLine($"\nDigite o {contador + 1}º Número:");
    numeros[contador] = double.Parse(Console.ReadLine());
}

Console.WriteLine(@$"
Digite a operacão que deseja realizar:
[+] -> Adição
[-] -> Subtração
[x] -> Multiplicação
[:] -> Divisão
");
string operacao = Console.ReadLine().ToLower();

switch(operacao){
    case "+":
        resultado = OperacaoSoma(numeros[0], numeros[1]);
        operacaoRealizada = "soma";
        break;

    case "-":
        resultado = OperacaoSubtracao(numeros[0], numeros[1]);
        operacaoRealizada = "subtração";
        break;

    case "x":
        resultado = OperacaoMultiplicacao(numeros[0], numeros[1]);
        operacaoRealizada = "multiplicação";
        break;
    
    case ":":
        resultado = OperacaoDivisao(numeros[0], numeros[1]);
        operacaoRealizada = "divisão";
        break;

    default:
        do{
            Console.WriteLine($"Operação Digitada Inválida.");
            Console.WriteLine(@$"Escolha entre uma das opções abaixo:
[+] -> Adição
[-] -> Subtração
[x] -> Multiplicação
[:] -> Divisão
");
            operacao = Console.ReadLine().ToLower();
        } while((operacao != "+") && (operacao != "-") && (operacao != "x") && (operacao != ":"));
        break;
}

Console.WriteLine($"\nO resultado da {operacaoRealizada} realizada é: {resultado}");
