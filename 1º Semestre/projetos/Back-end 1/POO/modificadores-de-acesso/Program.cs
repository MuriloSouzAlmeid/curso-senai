using Personagens;

public class Program
{
    private static void Main(string[] args)
    {
        Protagonista Luffy = new Protagonista("Monkey D. Luffy", 19, "One Piece");
        Console.WriteLine($"Nome: {Luffy.nome}, Idade: {Luffy.idade}, Universo: {Luffy.universo}");

        // Não há como instanciar um objeto por ser uma classe com atributos privados
        // Antagonista Madara = new Antagonista("Madara Uchiha", 40, "Naruto");
    }
}