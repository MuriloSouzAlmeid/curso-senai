using jogador_de_futebol;
using jogador_de_futebol.tipo_jogador;

// Funções --------------------------------------------------------------------------------------------
static void VerificarResposta(string respostaVazia){
    while(respostaVazia == ""){
        Console.WriteLine($"\nResposta inválida. Não há como receber uma resposta em branco. Informe uma nova resposta:");
        respostaVazia = Console.ReadLine()!;
    }
}

static int VerificarData(string respostaEnviada, DateTime dataAtual, int indice){
    while(respostaEnviada == ""){
        Console.WriteLine($"\nResposta inválida. Não há como receber uma resposta em branco. Informe uma nova resposta:");
        respostaEnviada = Console.ReadLine()!;
    }
    int dataFinal =  int.Parse(respostaEnviada);
    while((dataFinal < 1 || dataFinal > 31) && indice == 0){
        Console.WriteLine($"\nDia informado inválido, digite um número condizente:");
        dataFinal = int.Parse(Console.ReadLine()!);
    }
    while((dataFinal < 1 || dataFinal > 12) && indice == 1){
        Console.WriteLine($"\nMês informado inválido, digite um número condizente:");
        dataFinal = int.Parse(Console.ReadLine()!);
    }
    while((dataFinal < 1 || dataFinal > dataAtual.Year) && indice == 2){
        Console.WriteLine($"\nDia informado inválido, digite um número condizente:");
        dataFinal = int.Parse(Console.ReadLine()!);
    }
    return dataFinal;
}

static float VerificarNumero(string respostaInformada){
    while(respostaInformada == ""){
        Console.WriteLine($"\nResposta inválida. Não há como receber uma resposta em branco. Informe uma nova resposta:");
        respostaInformada = Console.ReadLine()!;
    }
    float numeroFinal = float.Parse(respostaInformada);
    while(numeroFinal <= 0){
        Console.WriteLine($"\nNúmero informado baixo demais. Informe um número maior:");
        numeroFinal = float.Parse(Console.ReadLine()!);
    }
    return numeroFinal;
}
// ----------------------------------------------------------------------------------------------------

DateTime dataAtual = DateTime.Now;

Console.WriteLine($"\nDados do Jogador\n");

Console.WriteLine($"Informe o nome do Jogador:");
string nome = Console.ReadLine()!;
VerificarResposta(nome);

int[] dataNascimento = new int[3];
for(int indice = 0; indice < dataNascimento.Length; indice++){
    string[] campoAtual = {"dia", "mês", "ano"};
    Console.WriteLine($"\nInforme o {campoAtual[indice]} (em números) na qual este jogador nasceu:");
    string dataInformada = Console.ReadLine()!;
    dataNascimento[indice] = VerificarData(dataInformada, dataAtual, indice);
}

Console.WriteLine($"\nInforme a Nacionalidade do Jogador:");
string nacionalidade = Console.ReadLine()!;
VerificarResposta(nacionalidade);

Console.WriteLine($"\nInforme a altura (em metros) do jogador:");
string alturaInformada = Console.ReadLine()!;
float altura = VerificarNumero(alturaInformada);

Console.WriteLine($"\nInforme o peso (em quilos) do jogador:");
string pesoInformado = Console.ReadLine()!;
float peso = VerificarNumero(pesoInformado);