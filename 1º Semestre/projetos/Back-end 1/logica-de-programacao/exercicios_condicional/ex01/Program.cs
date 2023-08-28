// Gerenciando o Orçamento

// Faça um programa que o usuário informe o salário recebido e o total gasto. Deverá ser exibido na tela “Gastos dentro do orçamento” caso o valor gasto não ultrapasse o valor do salário e “Orçamento estourado” se o valor gasto ultrapassar o valor do salário.

// Início

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(@$"
=======================================================================
                  PROGRAMA DE GERENCIAMENTO DE GASTOS
=======================================================================
");
Console.ResetColor();

// Entrada

Console.WriteLine($"Quanto você recebeu de salário nesse mês?");
float salario = float.Parse(Console.ReadLine());

Console.WriteLine($"Quanto você gastou de dinheiro nesse mês?");
float totalGasto = float.Parse(Console.ReadLine());

// Processamento

if (salario >= totalGasto){
    // Saída
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(@$"
Não se preocupe, seus gastos estão DENTRO DO SEU ORÇAMENTO!!");
    Console.ResetColor();
} else{
    // Saída
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(@$"
Tome cuidado, você está com o ORÇAMENTO ESTOURADO!!");
    Console.ResetColor();
}

// Fim
Console.WriteLine(@$"
========================================================================
                           Fim do Programa
========================================================================
");
