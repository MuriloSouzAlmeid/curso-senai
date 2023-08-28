// Cálculo de Imposto de Renda

//faça um método para calcular imposto sobre a renda

//Regras de Negócio:
//tabela de imposto vs renda
//até $1500 - isento
//de $1501 até $3500 - 20% de imposto
//de $3501 até $6000 - 25% de imposto
//acima de $6000 - 35% de imposto

// Início

using System.Globalization;

Console.WriteLine($"\nCálculo de Imposto de Renda\n");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(@$"
               /;;:;;\
            (:;/\,-,/\;;)
           (:;   o o  :;)
            (:;\__Y__/;;)-----------,,_
             ,..\  ,..\      ___/___)__`\
            (,,,)~(,,,)`-._##____________)
");
Console.ResetColor();

// Entradas

Console.WriteLine($"Informe quanto você recebe de salário bruto por mês:");
float salario = float.Parse(Console.ReadLine());

while(salario < 0){
    Console.WriteLine("Valor declarado inválido, digite um valo maior:");
    salario = float.Parse(Console.ReadLine());
}

// Processamento

// Funções

static float CalculoImposto(float imposto){

    if(imposto <= 1500){
        imposto = 0;
    } else if((imposto > 1500) && (imposto <= 3500)){
        imposto = imposto/5;
    } else if((imposto > 3500) && (imposto <= 6000)){
        imposto = imposto/4;
    } else{
        imposto = 0.35f * imposto;
    }

    return imposto;
}

float valorPago = CalculoImposto(salario);

// Saída

if(valorPago == 0){
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"\nDevido ao seu salário você está insento de imposto.\n");
    Console.ResetColor();
} else{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\nA quantia a ser paga de imposto de renda é {valorPago.ToString("C", new CultureInfo("pt-br"))}\n");
    Console.ResetColor();
}

// Fim