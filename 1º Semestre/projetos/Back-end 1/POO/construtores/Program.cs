using Personagens;

Protagonistas Luffy = new Protagonistas("Luffy", 19, "Se esticar e usar haki");
Antagonistas Madara = new Antagonistas("Madara", 40, "Sharingan, Células de Hashirama e Chakara do estilo fogo");

Console.WriteLine(@$"Nome: {Luffy.nome}, Idade: {Luffy.idade} anos e Habilidades: {Luffy.habilidades}
Nome: {Madara.nome}, Idade: {Madara.idade} anos e Habilidades: {Madara.habilidades}");
Console.Beep(1200, 100000);