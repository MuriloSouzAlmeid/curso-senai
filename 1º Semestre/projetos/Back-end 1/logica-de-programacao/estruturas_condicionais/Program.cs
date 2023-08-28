// Programa de ir para a praia
// Utilizado para aprender sobre Estruturas Condicionais


// Entradas
bool sol = true;
Console.WriteLine($"O dia está enssolarado? (Responda com 's' ou 'n')");
string respostaSol = Console.ReadLine().ToUpper();

if (respostaSol == "S"){
    sol = true;
} else {
    sol = false;
}

bool folga = true;
Console.WriteLine($"Você está de folga hoje? (Responda com 's' ou 'n')");
string respostaFolga = Console.ReadLine().ToUpper();

if (respostaFolga == "S"){
    folga = true;
} else {
    folga = false;
}




// Condicional Simples
// if(sol){
//     Console.WriteLine($"Vou para a praia!");  
// }





// Condicional Composta
// if(sol){
//     Console.WriteLine($"Vou para a praia!");  
// } else{
//     Console.WriteLine($"Eu vou é dormir!");
    
// }

// Operador Ternário

// string nome1 = "Murilo";
// string nome2 = "Amanda";

// string nomesIguais = (nome1 == nome2) ? "Nomes Iguais" : "Nomes Diferentes";

// Console.WriteLine($"{nomesIguais}");




// Condicional Encadeada
if(sol && folga){
    Console.WriteLine($"Vou para a praia!");  
} else if(folga == false){
        Console.WriteLine($"Eu tenho que trabalhar!");
} else{
        Console.WriteLine($"Eu vou é dormir!");
}

Console.WriteLine($"Fim do Programa");

bool careca = false;

if(!(careca == true)){
    Console.WriteLine($"SIM");
} else{
    Console.WriteLine($"NÃO");
}