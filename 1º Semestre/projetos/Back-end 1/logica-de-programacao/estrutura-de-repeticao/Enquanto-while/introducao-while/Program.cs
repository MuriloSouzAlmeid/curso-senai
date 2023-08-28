// Repetição - Enquanto
// serve para executar um bloco de comandos enquanto a condição especificada for verdadeira, apartir do momento que for falsa o laço de repetição para

int contador = 0;

// Enquanto o contador for menor ou igual a 10 (condição true), o bloco de repetição a seguir irá continuar até que o contador seja maior que 10
while(contador <= 10){ 
    Console.WriteLine($"{contador}"); // Imprime o valor do contador na tela
    contador+=2; // Incrementa + 1 no contador
}

// Ao chegar a 10 (condição false) o laço para e dá continuidade ao programa