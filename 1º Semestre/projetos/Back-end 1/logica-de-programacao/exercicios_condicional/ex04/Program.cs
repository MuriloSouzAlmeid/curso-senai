// Validação da Senha

// Escreva     um     programa     que     verifique     a     validade     de     uma     senha     fornecida pelo     usuário. 
// A     senha     válida     é     o     número     1234. 
// Devem     ser    impressas     as    seguintes     mensagens:
// ACESSO    PERMITIDO    caso    a    senha    seja    válida.
// ACESSO    NEGADO    caso    a    senha    seja    inválida.

// Início
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(@$"
===============================================================
                       Validando a Senha
===============================================================
");
Console.ResetColor();

// Entradas
string senhaSistema = "1234";

Console.WriteLine($"Digite a senha para continuar:");
string senhaDigitada = Console.ReadLine();


// Processamento

if (senhaDigitada == senhaSistema){
    Console.ForegroundColor = ConsoleColor.Green;
    // Saída
    Console.WriteLine(@$"
ACESSO PERMITDO");
Console.ResetColor();
} else{
    Console.ForegroundColor = ConsoleColor.Red;
    // Saída
    Console.WriteLine(@$"
ACSSO NEGADO");
Console.ResetColor();
}

// Fim

Console.WriteLine(@$"
========================================================================
                           Fim do Programa
========================================================================
");
