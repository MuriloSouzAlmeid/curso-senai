using Animais;

internal class Program
{
    private static void Main(string[] args)
    {
        Animal somAnimais = new Animal();
        Animal porco = new Porco();
        Animal cachorro = new Cachorro();

        somAnimais.somAnimal();
        porco.somAnimal();
        cachorro.somAnimal();
        
    }
}