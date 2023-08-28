using listagem_de_carros;

List<Carro> carros = new List<Carro>();

Console.Clear();
Console.WriteLine($"\nPrograma para listar carros:\n");

//Usando Construtor Completo
for(int contador = 1; contador <= 2; contador ++){
    Console.WriteLine($"\nInforme a marca do {contador}º carro:");
    string marcaInformada = Console.ReadLine()!;
    Console.WriteLine($"\nInforme a cor do {contador}º carro:");
    string corInformada = Console.ReadLine()!;

    carros.Add(
        new Carro(marcaInformada, corInformada)
    );
}

// Usando Construtor Simples
// for(int contador = 1; contador <= 2; contador ++){
//     Carro carro = new Carro();
//     Console.WriteLine($"\nInforme a marca do {contador}º carro:");
//     carro.Marca = Console.ReadLine()!;
//     Console.WriteLine($"\nInforme a cor do {contador}º carro:");
//     carro.Cor = Console.ReadLine()!;
//     carros.Add(carro);
// }

Console.WriteLine($"\nLista de Carros Cadastrados:\n");
foreach(var carro in carros){
    Console.WriteLine($"Marca: {carro.Marca}, Cor: {carro.Cor}");
}

Console.WriteLine($"\nPressione ENTER para finalizar:");
Console.ReadLine();