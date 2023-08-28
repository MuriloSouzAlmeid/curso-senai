// Proposta

using calculadora;

// Início

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();

// Funções ========================================================================================================================================
// Função que chama o menu de opções --------------------------------------------------------------------------------------------------------------

static void OpcoesOperacoes(){
Console.WriteLine(@$"[+] -> Adição
[-] -> Subtração
[x] -> Multiplicação
[:] -> Divisão");
}

// ================================================================================================================================================

// Título do Programa

Console.WriteLine("\nPrograma de Calculadora Orientada a Objetos\n");

// Entrada de Dados

// Array de números
float[] numeros = new float[2];
        
Console.ForegroundColor = ConsoleColor.Yellow;
for(int contador = 0; contador < (numeros.Length); contador++){
    Console.WriteLine($"\nDigite o {contador + 1}º número:");
    numeros[contador] = float.Parse(Console.ReadLine()!);
}
Console.ResetColor();

// Menu opções
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"Informe a operação que deseja realizar:\n");
OpcoesOperacoes();
string operacao = Console.ReadLine()!;

while((operacao != "+") && (operacao != "-") && (operacao != "x") && (operacao != ":")){
    Console.WriteLine($"\nOpção informada inválida, escolha entre as opções disponíveis abaixo:");
    OpcoesOperacoes();
    operacao = Console.ReadLine()!;
}
Console.ResetColor();

// Processamento

// Instanciando um novo objeto passando as variáveis obtdas como parâmetro
Calculadora Calculo = new Calculadora(operacao, numeros[0], numeros[1]);

// Saída
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"\nO resultado da conta é: {Calculo.EfetuarConta()}\n");
Console.ResetColor();

}
} 

// Fim