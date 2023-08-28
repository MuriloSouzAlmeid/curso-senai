// Projeto CRUD com listas

using listas_objetos;

List<Produto> produtos = new List<Produto>();

// Create --------------------------------------------------------------------------------------------------------------------------------------

// Método de criar um objeto diretamente na lista
produtos.Add(
    new Produto(1234, "Tomates secos", 13.89f)
);

produtos.Add(
    new Produto(4321, "Vinho Luccarelli", 376.90f)
);

// Método de criar um objeto por fora da lista e adicioná-lo posteriormente
Produto paoDeMel = new Produto(3456, "Pão de Mel", 7.99f);
produtos.Add(paoDeMel);

// Read -----------------------------------------------------------------------------------------------------------------------------------------

Console.Clear();
// Percorrendo a lista com foreach
Console.WriteLine($"\n=====================================================================");
Console.WriteLine($"|                           Produtos Listados:                        |");
foreach(var item in produtos){
    Console.WriteLine($"|-------------------------------------------------------------------|");
    Console.WriteLine($"| Código: {item.Codigo}, Produto: {item.Nome}, Preço: {item.Preco:C2}, Índice: {produtos.IndexOf(item)} |");
}
Console.WriteLine($"|-------------------------------------------------------------------|");
Console.WriteLine($"====================================================================");

// Update ---------------------------------------------------------------------------------------------------------------------------------------

// Expressão Lâmbda ou Função Anônima
Produto produtoBuscado = produtos.Find(x => x.Codigo == 4321)!;

Console.WriteLine($"Código: {produtoBuscado.Codigo}, Nome: {produtoBuscado.Nome}, Preço: {produtoBuscado.Preco} Índice: {produtos.IndexOf(produtoBuscado)}");

int indiceProduto = produtos.IndexOf(produtoBuscado);

produtoBuscado.Preco = 349.99f;

// Remove o objeto com o índice passado como parâmetro
produtos.RemoveAt(indiceProduto);

// Insere um objeto para uma lista passando como parâmetro o índice desejado e o objeto que vai ser inserido na lista
produtos.Insert(indiceProduto, produtoBuscado);

Console.WriteLine($"\n=====================================================================");
Console.WriteLine($"|              Produtos Listados (Atualizado):                        |");
foreach(var item in produtos){
    Console.WriteLine($"|-------------------------------------------------------------------|");
    Console.WriteLine($"| Código: {item.Codigo}, Produto: {item.Nome}, Preço: {item.Preco:C2}, Índice: {produtos.IndexOf(item)} |");
}
Console.WriteLine($"|-------------------------------------------------------------------|");
Console.WriteLine($"=====================================================================");