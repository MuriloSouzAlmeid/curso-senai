// Lista de Exercícios de Fixção

using System.Globalization;

int resposta;
string respostaRepetir = "";
bool respostaSatisfeita = false;

// Funções

static string VerfificaResposta(string respostaFornecida){
    while(((respostaFornecida != "S") && (respostaFornecida != "N") || (respostaFornecida == ""))){
        Console.WriteLine($"Opção informada inválida, escolha entre (s) para sim ou (n) para não:");
        respostaFornecida = Console.ReadLine()!.ToUpper();
    }

    return respostaFornecida;
}

static void FinalizaPrograma(){
    Console.WriteLine($"\nOk senhor(a). Para finalizar o programa pressione ENTER:");
    Console.ReadLine();
    Environment.Exit(0);
}

static bool VoltarParaMenu(bool resposta){
    string voltarMenu;
    Console.WriteLine($"\nDeseja voltar ao menu de exercícios? (s/n)");
    voltarMenu = Console.ReadLine()!.ToUpper();
    voltarMenu = VerfificaResposta(voltarMenu);
    if(voltarMenu == "S"){
        resposta = false;
    } else{
        FinalizaPrograma();
    }

    return resposta;
}

static string RepetirExercicio(string resposta){
    Console.WriteLine($"\nDeseja Repetir o Exercício? (s/n)");
    resposta = Console.ReadLine()!.ToUpper();
    resposta = VerfificaResposta(resposta);

    return resposta;
}

static void Exercicio01(){
    // Poderá votar ou não

    // Ler o ano atual e o ano de nascimento de uma pessoa. Escrever uma mensagem que diga se ela poderá ou não votar este ano (não é necessário considerar o mês em que a pessoa nasceu).

    //Início
    Console.WriteLine($"\nJá pode votar?\n");

    // Entradas
    var dataAtual = DateTime.Now;

    Console.WriteLine($"Informe o ano em que você nasceu:");
    int anoNascido = int.Parse(Console.ReadLine()!);

    int idade = dataAtual.Year - anoNascido;

    // Processamento e Saída

    if(idade < 16){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nSinto muito, mas você ainda não possui idade suficiente para votar.\n");
    } else{
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nVocê já possui idade o suficiente para votar, vote com calma e sabedoria!\n");
    }
    Console.ResetColor();

    //Fim
}

static void Exercicio02(){
    // Gasolina ou Alcool?

// Um posto está vendendo combustíveis com a seguinte tabela de descontos:

// Álcool:
// . até 20 litros, desconto de 3% por litro Álcool
// . acima de 20 litros, desconto de 5% por litro 

// Gasolina:
// . até 20 litros, desconto de 4% por litro Gasolina
// . acima de 20 litros, desconto de 6% por litro

// Escreva um algoritmo que leia o número de litros vendidos e o tipo de combustível (codificado
// da seguinte forma: A-álcool, G-gasolina), calcule e imprima o valor a ser pago pelo cliente
// sabendo-se que o preço do litro da gasolina é R$ 5,30 e o preço do litro do álcool é R$ 4,90.

// Início

Console.WriteLine($"\nGasolina ou Álcool?\n");

// Entrada

char tipoCombustivel;

// do{
//     Console.WriteLine($"Digite o tipo de combustível utilizado:");
//     Console.WriteLine(@$"
// [G] -> Gasolina.
// [A] -> Álcool");
//     tipoCombustivel = char.Parse(Console.ReadLine());
// }

// while((tipoCombustivel != 'g') && (tipoCombustivel != 'a'));

Console.WriteLine($"Digite o tipo de combustível utilizado:");
    Console.WriteLine(@$"
[G] -> Gasolina.
[A] -> Álcool");
    tipoCombustivel = char.Parse(Console.ReadLine()!);

while((tipoCombustivel != 'g') && (tipoCombustivel != 'a')){
    Console.WriteLine($"Opção escolhida inválida. Escolha entre [G] para Gasolina e [A] para Álcool.");
    tipoCombustivel = char.Parse(Console.ReadLine()!);
}

Console.WriteLine($"\nInforme quantos litros foram abastecidos deste combustível:");
float litrosAbastecidos = float.Parse(Console.ReadLine()!);

while(litrosAbastecidos <= 0){
    Console.WriteLine($"Quantidade informada inválida, informe uma quantidade maior:");
    litrosAbastecidos = float.Parse(Console.ReadLine()!);
}

// Processamento

static float CalculaValor(char tipoCombustivel, float litrosAbastecidos){
    float valor = 0;
    switch(tipoCombustivel){
        case 'g':
            if(litrosAbastecidos <= 20){
                valor = (litrosAbastecidos * 5.3f);
                valor = valor - (0.04f * valor);
            } else{
                valor = (litrosAbastecidos * 5.3f);
                valor = valor - (0.06f * valor);
            }
            break;

        case 'a':
            if(litrosAbastecidos <= 20){
                valor = (litrosAbastecidos * 4.9f);
                valor = valor - (0.03f * valor);
            } else{
                valor = (litrosAbastecidos * 4.9f);
                valor = valor - (0.05f * valor);
            }
            break;
    }

    return valor;
}

float valorTotal = CalculaValor(tipoCombustivel, litrosAbastecidos);

// Saída

Console.WriteLine($"\nO valor total a ser pago é {valorTotal.ToString("C", new CultureInfo("pt-br"))}");


// Fim
}

static void Exercicio03(){
    // Comprando na Biblioteca

// Faça um algoritmo para ler: a descrição do produto (nome), a quantidade adquirida e opreço unitário. Calcular e escrever o total (total = quantidade adquirida * preço unitário), o desconto e o total a pagar (total a pagar = total - desconto), sabendo-se que:
// - Se quantidade <= 5 o desconto será de 2%
// - Se quantidade > 5 e quantidade <= 10 o desconto será de 3%
// - Se quantidade > 10 o desconto será de 5%

// Início

Console.WriteLine($"\nCompras na Biblioteca\n");

// Entrada

Console.WriteLine($"Informe o Nome do livro que será comprado:");
string nomeLivro = Console.ReadLine()!;

Console.WriteLine($"\nInforme o preço do livro que será comprado:");
float precoLivro = float.Parse(Console.ReadLine()!);

Console.WriteLine($"\nInforme a quantidade da unidade que será comprada:");
int quantidadeLivro = int.Parse(Console.ReadLine()!);

// Processamento

static float CalculaDesconto(float precoLivro, int quantidadeLivro){
    float desconto = 0;
    if(quantidadeLivro <= 5){
        desconto = 0.02f * precoLivro;
    } else if(quantidadeLivro <= 10){
        desconto = 0.03f * precoLivro;
    } else{
        desconto = 0.05f * precoLivro;
    }

    return desconto;
}

float valorNormal = quantidadeLivro * precoLivro;
float totalDesconto = CalculaDesconto(precoLivro, quantidadeLivro);
float valorFinal = valorNormal - totalDesconto;

// Saída

Console.WriteLine($"\nResumo do Pedido:\n");
Console.WriteLine(@$"
Nome do Livro: {nomeLivro}.
Preço do Livro: {precoLivro}.
Quantidade a Comprada: {quantidadeLivro}.
Preço Total: {valorNormal.ToString("C", new CultureInfo("pt-br"))}.
Desconto Aplicado: {totalDesconto.ToString("C", new CultureInfo("pt-br"))}.
Valor Final da Compra: {valorFinal.ToString("C", new CultureInfo("pt-br"))}
");

// Fim
}

static void Exercicio04(){
    // Maior e menor

// Faça um programa que leia 10 valores digitados pelo usuário e no final, escreva o maior e o menor valor lido.

// Início

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\nQual é o Maior e qual é o Menor?");
Console.ResetColor();

// Entradas

float[] numerosDigitados = new float[10];

Console.ForegroundColor = ConsoleColor.Cyan;
for(int indice = 0; indice < 10; indice++){
    Console.WriteLine($"\nDigite o {indice + 1}º número a ser comparado:");
    numerosDigitados[indice] = float.Parse(Console.ReadLine()!);
}
Console.ResetColor();

// Processamento

static float CalculaMaiorNumero(float[] numerosDigitados){
    float maior = 0;
    foreach(float numero in numerosDigitados){
        if(numero > maior){
            maior = numero;
        }
    }
    return maior;
}

float maiorNumero = CalculaMaiorNumero(numerosDigitados);

static float CalculaMenorNumero(float[] numerosDigitados, float maiorNumero){
    float menor = maiorNumero;
    foreach(float numero in numerosDigitados){
        if(numero < menor){
            menor = numero;
        }
    }
    return menor;
}

float menorNumero = CalculaMenorNumero(numerosDigitados, maiorNumero);

// saída

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"\nDentre os números digitados o maior é o {maiorNumero} e o menor é o {menorNumero}\n");
Console.ResetColor();

// Fim
}

static void Exercicio05(){
    // Tabuada das Tabuadas

// Escreva um algoritmo que imprima a tabuada (de 1 a 10) para os números de 1 a 10. Exemplo: tabuada do 1, tabuada do 2, etc... Dica: utilize um laço dentro do outro.

// Início

Console.WriteLine($"\nTabuada das Tabuadas");

// Entradas

int tabuada;
int multiplicador;
int resultado;

// Processamento

for(tabuada = 1; tabuada <= 10; tabuada++){
    Console.WriteLine($"\nTabuada do {tabuada}:");
    for(multiplicador = 1; multiplicador <= 10; multiplicador++){
        resultado = multiplicador * tabuada;
        Console.WriteLine($"{tabuada} x {multiplicador} = {resultado}");
    }
}

Console.WriteLine();
// Fim
}

static void Exercicio06(){
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
    nomesCadastrados[indice] = Console.ReadLine()!.ToUpper();
}

Console.WriteLine("\nAgora Pesquise o nome que deseja que eu encontre:");
string nomePesquisado = Console.ReadLine()!.ToUpper();

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
}

static void Exercicio07(){
    // Os últimos serão os primeiros

// Faça um algoritmo para ler 15 números e armazenar em um vetor. Após a leitura total dos
// 15 números, o algoritmo deve escrever esses 15 números lidos na ordem inversa da qual foi
// declarado.

// Início

Console.WriteLine($"\nOs Últimos Serão Os primeiros");

// Entrada

float[] numerosDigitados = new float[15];
int indice;

for(indice = 0; indice < numerosDigitados.GetLength(0); indice++){
    Console.WriteLine($"\nDigite o {indice + 1}º número:");
    numerosDigitados[indice] = float.Parse(Console.ReadLine()!);
}

// Processamento e Saída
Console.WriteLine("\nPega o REVERSE!\n");
for(indice = numerosDigitados.GetLength(0) - 1; indice >= 0; indice--){
    Console.WriteLine($"{numerosDigitados[indice]}");
}

Console.WriteLine();

// Fim
}

//

do{
    
Console.Clear();
Console.WriteLine(@$"
===================================================
      |   Lista de Exercícios de Fixação   |
===================================================");

    Console.WriteLine(@$"
Escolha dentre os exercícios abaixo:
(1) -> Pode votar ou não?
(2) -> Preço do combustível
(3) -> Compras na biblioteca
(4) -> Maior e menor valor
(5) -> Tabuada das Tabuadas
(6) -> Procurando nomes
(7) -> Ordem reversa dos números

(0) -> Finalizar Programa
");
resposta = int.Parse(Console.ReadLine()!);

switch(resposta){
    case 1:
        respostaSatisfeita =  true;
        do{
            Console.Clear();
            Exercicio01();
            respostaRepetir = RepetirExercicio(respostaRepetir);
        } while(respostaRepetir == "S");
        respostaSatisfeita = VoltarParaMenu(respostaSatisfeita);
        break;
    case 2:
        respostaSatisfeita =  true;
        do{
            Console.Clear();
            Exercicio02();
            respostaRepetir = RepetirExercicio(respostaRepetir);
        } while(respostaRepetir == "S");
        respostaSatisfeita = VoltarParaMenu(respostaSatisfeita);
        break;
    case 3:
        respostaSatisfeita =  true;
        do{
            Console.Clear();
            Exercicio03();
            respostaRepetir = RepetirExercicio(respostaRepetir);
        } while(respostaRepetir == "S");
        respostaSatisfeita = VoltarParaMenu(respostaSatisfeita);
        break;
    case 4:
        respostaSatisfeita =  true;
        do{
            Console.Clear();
            Exercicio04();
            respostaRepetir = RepetirExercicio(respostaRepetir);
        } while(respostaRepetir == "S");
        respostaSatisfeita = VoltarParaMenu(respostaSatisfeita);
        break;
    case 5:
        respostaSatisfeita =  true;
        do{
            Console.Clear();
            Exercicio05();
            respostaRepetir = RepetirExercicio(respostaRepetir);
        } while(respostaRepetir == "S");
        respostaSatisfeita = VoltarParaMenu(respostaSatisfeita);
        break;
    case 6:
        respostaSatisfeita =  true;
        do{
            Console.Clear();
            Exercicio06();
            respostaRepetir = RepetirExercicio(respostaRepetir);
        } while(respostaRepetir == "S");
        respostaSatisfeita = VoltarParaMenu(respostaSatisfeita);
        break;
    case 7:
        respostaSatisfeita =  true;
        do{
            Console.Clear();
            Exercicio07();
            respostaRepetir = RepetirExercicio(respostaRepetir);
        } while(respostaRepetir == "S");
        respostaSatisfeita = VoltarParaMenu(respostaSatisfeita);
        break;
    case 0:
        FinalizaPrograma();
        break;
    default:
        Console.WriteLine($"Opção Inexistente.");
        Environment.Exit(0);
        break;
}

} while(respostaSatisfeita == false);