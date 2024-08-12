// See https://aka.ms/new-console-template for more information
string[] alfabetoArray = "a b c d e f g h i j k l m n o p q r s t u v w x y z".Split(" ");

Console.WriteLine($"Digite um texto a ser analizado");
string texto = Console.ReadLine()!.Trim();

if(texto == ""){
    Console.WriteLine($"Nenhum texto foi digitado");
}

Console.WriteLine($"");
int qtdExecucaoLoop = 0;
foreach(string letraAlfabeto in alfabetoArray){
    int qtdLetra = 0;

    foreach(char caractereLetra in texto){
        if(letraAlfabeto.Equals(caractereLetra.ToString().ToLower())){
            qtdLetra++;
        }
    }

    if(qtdLetra > 0){
        Console.WriteLine($"{letraAlfabeto} = {qtdLetra}");
        qtdExecucaoLoop++;
    }
}