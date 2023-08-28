namespace Animais{
    public class Animal{
        // usamos o virtual para dizer que este é apenas um método temporário e que posteriormente poderá ser substituído por outros métodos de classes herdadas
        public virtual void somAnimal(){
            Console.WriteLine($"Os sons que os animais fazem:");
        }
    }

    public class Porco : Animal{
        // usamos o override para dizer que este método irá substituir o método temporário (virtual) de uma classe pai
        public override void somAnimal(){
            Console.WriteLine($"O porco faz um som parecido com: oink oink");
        }
    }

    public class Cachorro : Animal{
        public override void somAnimal(){
            Console.WriteLine($"O cachorro faz um som parecido com: au au");
            
        }
    }
}