// Procurando o Nome

// Escreva um algoritmo que permita a leitura dos nomes de 10 pessoas e armazene os nomes
// lidos em um vetor. Após isto, o algoritmo deve permitir a leitura de mais 1 nome qualquer de
// pessoa (para efetuar uma busca) e depois escrever a mensagem ACHEI, se o nome estiver
// entre os 10 nomes lidos anteriormente (guardados no vetor), ou NÃO ACHEI caso contrário.

// Início

Console.WriteLine($"\nProcurando Nomes");

// Entrada

string[] nomesCadastrados = new string[10];

for(int indice = 0; indice < nomesCadastrados.GetLength(0); indice++){
    Console.WriteLine($"\nDigite o {indice + 1} nome a ser cadastrado:");
    nomesCadastrados[indice] = Console.ReadLine().ToUpper();
}

Console.WriteLine("\nAgora Pesquise o nome que deseja que eu encontre:");
string nomePesquisado = Console.ReadLine().ToUpper();

// Processamento

static bool EncontrarNome(string[] nomesCadastrados, string nomePesquisado){
    bool encontrado = false;
        foreach(string nome in nomesCadastrados){
            if(nome == nomePesquisado){
                encontrado = true;
            }
        }
    return encontrado;
}

bool nomeEncontrado = EncontrarNome(nomesCadastrados, nomePesquisado);

// saída

// Console.WriteLine(nomeEncontrado == true ? $"\nACHEI. Muito bem senhor(a) {nomePesquisado} parece que seu nome está de fato na lista.\n" : $"\nNÃO ACHEI. sinto muito senhor(a) {nomePesquisado} parece que seu nome não está presente na lista.\n");

Console.WriteLine(nomeEncontrado ? $"\nACHEI. Muito bem senhor(a) {nomePesquisado} parece que seu nome está de fato na lista.\n" : $"\nNÃO ACHEI. sinto muito senhor(a) {nomePesquisado} parece que seu nome não está presente na lista.\n");

// Fim