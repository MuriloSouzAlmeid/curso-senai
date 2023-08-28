// Vogal ou Consoante

// Faça um programa que verifique se uma letra digitada é vogal ou consoante

// Início

Console.WriteLine(@$"
Vogal ou Consoante?
");

// Entradas

Console.WriteLine($"Digite uma letra do teclado:");
string letraDigitada = Console.ReadLine().ToUpper();

// Processamento

if(letraDigitada == ""){
    Console.WriteLine(@$"
Letra não digitada, tente novamente.");
} else if ((letraDigitada == "A") || (letraDigitada == "E") || (letraDigitada == "I") || (letraDigitada == "O") || (letraDigitada == "U")){
Console.WriteLine(@$"
A letra digitada ({letraDigitada}) é uma vogal.");
} else{
Console.WriteLine(@$"
A letra digitada ({letraDigitada}) é uma consoante.");
}

// Fim