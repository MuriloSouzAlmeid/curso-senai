// Exibição de Dados com Array

// Início

Console.WriteLine($"\nExibição de Dados com Array\n");

string[] nomes = new string[5];
int[] idades = new int[5];
int indice;

for(indice = 0; indice < nomes.GetLength(0); indice++){
    Console.WriteLine($"\nDigite o nome da {indice + 1}º pessoa:");
    nomes[indice] = Console.ReadLine();
    Console.WriteLine($"Digite agora a idade dessa pessoa:");
    idades[indice] = int.Parse(Console.ReadLine());
}

for(indice = 0; indice < nomes.GetLength(0); indice++){
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"\n{indice + 1}) nome: {nomes[indice]}");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"idade: {idades[indice]}\n");
    Console.ResetColor();
}

// Fim