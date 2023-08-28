// Idade do Artista

// Início

Console.WriteLine(@$"Eaí, você sabe qual é a idade do nosso mestre Eiichiro Oda (autor de One Piece)?
");

// Entradas

// Declara a idade inicialmente como false para podermos trabalhar com ela no laço
bool idadeCerta = false;
int idadeOda = 48;
int chuteIdade = 0;

Console.WriteLine($"Dá um chute aí parceiro:");
     chuteIdade = int.Parse(Console.ReadLine());
     
 

// while(idadeCerta == false){
//     Console.WriteLine($"Dá um chute aí parceiro:");
//     chuteIdade = int.Parse(Console.ReadLine());

//     if(chuteIdade == idadeOda){ // Se o chute for igual a idadeOda então o laço termina
//         idadeCerta = true;
//     } else{ // Se não o laço reinicia mais uma vez para uma nova tentativa
//         Console.WriteLine(@$"
// Não foi dessa vez, tenta mais uma aí.");
//     }
// }

do{
     if(chuteIdade == idadeOda){ // Se o chute for igual a idadeOda então o laço termina
         idadeCerta = true;
    } else{ // Se não o laço reinicia mais uma vez para uma nova tentativa
         Console.WriteLine(@$"
Não foi dessa vez, tenta mais uma aí.");
     chuteIdade = int.Parse(Console.ReadLine());
}
}
while(idadeCerta == false);

Console.WriteLine(@$"
Parabéns, você acertou!");
