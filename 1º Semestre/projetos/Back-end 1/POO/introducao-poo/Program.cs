using introducao_poo.Personagens;

Personagem p1 = new Personagem();

Console.WriteLine($"\nInforme o nome do personagem:");
p1.nome = Console.ReadLine()!;

Console.WriteLine($"\nInforme a idade do personagem");
p1.idade = int.Parse(Console.ReadLine()!);

Console.WriteLine($"\nInforme qual o poder do personagem:");
p1.poder = Console.ReadLine()!;

Console.WriteLine($"\nInforme de qual universo é esse personagem:");
p1.universo = Console.ReadLine()!;

Console.WriteLine(@$"
Nome: {p1.nome}
Idade: {p1.idade}
Poder: {p1.poder}
Universo do personagem: {p1.universo}
");

p1.Atacar();
p1.Defender();

string respPoder = p1.UsouPoder();

Console.WriteLine($"{respPoder} {p1.poder}!!!");
