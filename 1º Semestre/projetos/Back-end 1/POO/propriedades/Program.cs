using Personagens;

internal class Program
{
    private static void Main(string[] args)
    {
        Protagonista Luffy = new Protagonista("Monkey D. Luffy", 19, "One Piece");
        Console.WriteLine($"Nome: {Luffy.Nome}, Idade: {Luffy.Idade}, Universo: {Luffy.Universo}");
        

    }
}