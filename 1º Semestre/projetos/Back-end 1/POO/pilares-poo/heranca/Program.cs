using Carros;

internal class Program
{
    private static void Main(string[] args)
    {
        Carro Mustang = new Carro("Ford", "Mustang", 1969);

        Console.WriteLine($"Marca: {Mustang.marca}, Modelo: {Mustang.modelo}, Ano: {Mustang.ano}");

        Console.WriteLine($"\nDeseja acelerar com seu Mustang? (s/n)");
        string resposta = Console.ReadLine()!.ToUpper();
        while((resposta != "S" && resposta != "N") || resposta == ""){
            Console.WriteLine($"Opção informada inválida, escola entre (s) para sim ou (n) para não:");
            resposta = Console.ReadLine()!.ToUpper();
        }
        Mustang.Acelerar(resposta);
    }
}