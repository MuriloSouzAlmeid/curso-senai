// Média de Idades e Pesos

// Faça um programa que receba a idade, o peso e o sexo de 10 pessoas. Calcule e imprima:
      
// A.Total de Homens;      
// B.Total de Mulheres;      
// C.Média de idade dos Homens;      
// D.Média de idade das mulheres.

// Início

Console.WriteLine($"\nMédia de Idades\n");

int totalHomens = 0;
int totalMulheres = 0;

int idade = 0;
int idadeHomens = 0;
int idadeMulheres = 0;

float peso = 0f;
float pesoHomens = 0f;
float pesoMulheres = 0f;

string sexo = ""; 

for(int pessoas = 1; pessoas <=10; pessoas++){
    Console.WriteLine($"\nPessoa {pessoas}:\n");
    Console.WriteLine(@$"Qual o seu sexo:
[M] -> Masculino
[F] -> Feminino");
    sexo = Console.ReadLine().ToUpper();

    switch(sexo){
        case "M":
            totalHomens++;
            break;

        case "F":
            totalMulheres++;
            break;
        
        default:
            do{
                Console.WriteLine($"Opção selecionada invádila, selecione entre [M] (masculino) ou [F] (feminino:)");
                sexo = Console.ReadLine().ToUpper();
                if(sexo == "M"){
                    totalHomens++;
                }

                if(sexo == "F"){
                    totalMulheres++;
                }
            } while((sexo != "M") && (sexo != "F"));
            break;
    }
    
    Console.WriteLine($"\nQual a sua idade?");
    idade = int.Parse(Console.ReadLine());
    while(idade < 0){
        Console.WriteLine($"\nIdade digitada inválida, digite uma idade maior:");
        idade = int.Parse(Console.ReadLine());
    }

    switch(sexo){
        case "M":
            idadeHomens = idadeHomens + idade;
            break;

         case "F":
            idadeMulheres = idadeMulheres + idade;
            break;
    }


    Console.WriteLine($"\nQual o seu peso?");
    peso = float.Parse(Console.ReadLine());
    while(peso < 0){
        Console.WriteLine($"\nPeso digitado inválida, digite um peso maior:");
        peso = float.Parse(Console.ReadLine());
    }

    switch(sexo){
        case "M":
            pesoHomens = pesoHomens + peso;
            break;

         case "F":
            pesoMulheres = pesoMulheres + peso;
            break;
    }
}

float mediaIdadeHomens = idadeHomens / totalHomens;

float mediaIdadeMulheres = idadeMulheres / totalMulheres;

Console.WriteLine($"\nAgradecemos a resposta!\n");
Console.WriteLine(@$"Dados coletados da pesquisa:
Total de homens que responderam: {totalHomens}
Total de mulheres que responderam: {totalMulheres}
A média das idades dos homens na pesquisa é: {mediaIdadeHomens}
A média das idades dos homens na pesquisa é: {mediaIdadeMulheres}
");


// Fim