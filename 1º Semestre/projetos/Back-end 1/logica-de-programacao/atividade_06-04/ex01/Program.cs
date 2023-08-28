// Validação da Nota

// Faça um programa que peça uma nota, entre zero e dez. Mostre uma mensagem caso o valor seja inválido e continue pedindo até que o usuário informe um valor válido.

// Início

Console.WriteLine($"\nValidando Notas\n");

Console.WriteLine($"Digite uma nota de 0 a 10 para o nosso programa:");
float nota = float.Parse(Console.ReadLine());

while((nota < 0) || (nota > 10)){
    if(nota < 0){
        Console.WriteLine($"\nNota digitada inválida, digite uma nota maior:");
        nota = float.Parse(Console.ReadLine());
    } else{
        Console.WriteLine($"\nNota digitada inválida, digite uma nota menor:");
        nota = float.Parse(Console.ReadLine());
    }
}

Console.WriteLine($"\nMuito bem senhor(a), agradecemos o feedback. Nota: {nota}");

// Fim