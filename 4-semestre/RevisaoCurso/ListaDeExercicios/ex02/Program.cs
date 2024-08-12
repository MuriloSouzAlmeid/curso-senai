// See https://aka.ms/new-console-template for more information
string[] nomes = new string[5];

for(int i = 0; i < nomes.Length; i++){
    Console.WriteLine($"Informe o nome do {i + 1}º usuário");
    nomes[i] = Console.ReadLine()!;
}
Console.WriteLine($"");

foreach(string nome in nomes.Order()){
    Console.WriteLine($"{nome}");
}