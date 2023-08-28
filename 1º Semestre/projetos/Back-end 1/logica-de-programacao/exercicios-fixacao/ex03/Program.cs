// Comprando na Biblioteca

// Faça um algoritmo para ler: a descrição do produto (nome), a quantidade adquirida e opreço unitário. Calcular e escrever o total (total = quantidade adquirida * preço unitário), o desconto e o total a pagar (total a pagar = total - desconto), sabendo-se que:
// - Se quantidade <= 5 o desconto será de 2%
// - Se quantidade > 5 e quantidade <= 10 o desconto será de 3%
// - Se quantidade > 10 o desconto será de 5%

// Início


using System.Globalization;

Console.WriteLine($"\nCompras na Biblioteca\n");

// Entrada

Console.WriteLine($"Informe o Nome do livro que será comprado:");
string nomeLivro = Console.ReadLine();

Console.WriteLine($"\nInforme o preço do livro que será comprado:");
float precoLivro = float.Parse(Console.ReadLine());

Console.WriteLine($"\nInforme a quantidade da unidade que será comprada:");
int quantidadeLivro = int.Parse(Console.ReadLine());

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