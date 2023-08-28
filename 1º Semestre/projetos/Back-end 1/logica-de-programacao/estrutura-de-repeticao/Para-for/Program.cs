// Estrutura de repetição For

// Sintaxe
// for(inicializador; condição; interador){
//     Bloco de Comandos
// }
//inicializador -> declarar uma variável que terá um valor inicial
//condição -> a condição com o inicializador para que o laço execute
//interador -> a quantidade de valor que é adicionada ao inicializador até que acabe o laço









Console.WriteLine($"Contador Crescente:");

for(int contadorCrescente = 0; contadorCrescente <= 500; contadorCrescente+=5){
    Console.WriteLine($"{contadorCrescente}");
}

Console.WriteLine($"\n");

Console.WriteLine($"Contador Decrescente:");

for(int contadorDecrescente = 500; contadorDecrescente >= 0; contadorDecrescente-=5){
    Console.WriteLine($"{contadorDecrescente}");
}