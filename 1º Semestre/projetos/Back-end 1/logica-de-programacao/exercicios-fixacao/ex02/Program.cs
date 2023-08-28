// Gasolina ou Alcool?

// Um posto está vendendo combustíveis com a seguinte tabela de descontos:

// Álcool:
// . até 20 litros, desconto de 3% por litro Álcool
// . acima de 20 litros, desconto de 5% por litro 

// Gasolina:
// . até 20 litros, desconto de 4% por litro Gasolina
// . acima de 20 litros, desconto de 6% por litro

// Escreva um algoritmo que leia o número de litros vendidos e o tipo de combustível (codificado
// da seguinte forma: A-álcool, G-gasolina), calcule e imprima o valor a ser pago pelo cliente
// sabendo-se que o preço do litro da gasolina é R$ 5,30 e o preço do litro do álcool é R$ 4,90.

// Início

using System.Globalization;

Console.WriteLine($"\nGasolina ou Álcool?\n");

// Entrada

char tipoCombustivel;
float valor = 0;

// do{
//     Console.WriteLine($"Digite o tipo de combustível utilizado:");
//     Console.WriteLine(@$"
// [G] -> Gasolina.
// [A] -> Álcool");
//     tipoCombustivel = char.Parse(Console.ReadLine());
// }

// while((tipoCombustivel != 'g') && (tipoCombustivel != 'a'));

Console.WriteLine($"Digite o tipo de combustível utilizado:");
    Console.WriteLine(@$"
[G] -> Gasolina.
[A] -> Álcool");
    tipoCombustivel = char.Parse(Console.ReadLine());

while((tipoCombustivel != 'g') && (tipoCombustivel != 'a')){
    Console.WriteLine($"Opção escolhida inválida. Escolha entre [G] para Gasolina e [A] para Álcool.");
    tipoCombustivel = char.Parse(Console.ReadLine());
}

Console.WriteLine($"\nInforme quantos litros foram abastecidos deste combustível:");
float litrosAbastecidos = float.Parse(Console.ReadLine());

while(litrosAbastecidos <= 0){
    Console.WriteLine($"Quantidade informada inválida, informe uma quantidade maior:");
    litrosAbastecidos = float.Parse(Console.ReadLine());
}

// Processamento

static float CalculaValor(char tipoCombustivel, float litrosAbastecidos){
    float valor = 0;
    switch(tipoCombustivel){
        case 'g':
            if(litrosAbastecidos <= 20){
                valor = (litrosAbastecidos * 5.3f);
                valor = valor - (0.04f * valor);
            } else{
                valor = (litrosAbastecidos * 5.3f);
                valor = valor - (0.06f * valor);
            }
            break;

        case 'a':
            if(litrosAbastecidos <= 20){
                valor = (litrosAbastecidos * 4.9f);
                valor = valor - (0.03f * valor);
            } else{
                valor = (litrosAbastecidos * 4.9f);
                valor = valor - (0.05f * valor);
            }
            break;
    }

    return valor;
}

float valorTotal = CalculaValor(tipoCombustivel, litrosAbastecidos);

// Saída

Console.WriteLine($"\nO valor total a ser pago é {valorTotal.ToString("C", new CultureInfo("pt-br"))}");


// Fim