Console.WriteLine($"Digite um número");
string nT = Console.ReadLine();

try
{
    // Se isso der certo
    int n = int.Parse(nT);


    // Fazer isso
    Console.WriteLine($"O número é: {n} seu dobro é {n * 2}");

}
// Se não der certo -> Erro System
catch (System.Exception e)
{
    // Faça Isso
    Console.WriteLine($"NÃO COLOQUE UMA LETRA!!!");

    // Erro que aconteceu
    Console.WriteLine($"Erro: {e.Message}");
    
}