// Custo das Maçãs

// As    maçãs custam R$ 0,30 cada se forem compradas    menos do que uma dúzia, e R$ 0,25 se forem compradas pelo menos doze. Escreva um programa que leia o número de maçãs compradas, calcule e escreva o valor    total    da compra.

// Início

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(@$"
=============================================================
                Quanto custou minhas maçãs?
=============================================================
");
Console.ResetColor();

// Entradas

float precoNormal = 0.3F;
float precoPromocional = 0.25F;
float valorGasto = 0f;

Console.WriteLine($"Informe a quantidade de maçãs compradas:");
int macasCompradas = int.Parse(Console.ReadLine());

// Processamento

if (macasCompradas >= 12){
    valorGasto = macasCompradas * precoPromocional;
} else{
    valorGasto = macasCompradas * precoNormal;
}

// Saída
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(@$"
O valor Total gasto na compra foi R${valorGasto} reais.");
Console.ResetColor();

// Fim

Console.WriteLine(@$"
========================================================================
                            Fim do Programa
========================================================================
");