namespace introducao_poo.Personagens
{
    public class Personagem
    {
        // Atributos: Nome, Idade, Poder, Universo.

        public string nome;

        public int idade;

        public string poder;

        public string universo;

        //Métodos: Atacar, Defender, Usar Poder

        public void Atacar(){
            Console.WriteLine($"O personagem atacou!!!");
        }

        public void Defender(){
            Console.WriteLine($"O personagem defendeu!!!");
        }

        public string UsouPoder(){
            string respostaPoder = "O personagem usou seu poder de";
            
            return respostaPoder;
        }

    }
}