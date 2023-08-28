namespace Personagens{
    public class Protagonista{
        private string nome;
        private int idade;
        private string universo;

        // Getters and Setters, servem para receber um valor de um lugar e atribui-lo em outro, podendo assim aptribuir valores para atributos privados.
        public string Nome{
            get {return nome;}
            set {nome = value;}
        }

        public int Idade{
            get {return idade;}
            set {idade = value;}
        }

        public string Universo{get; set;}

        public Protagonista(string nomeInformado, int idadeInformada, string universoInformado){
            Nome = nomeInformado;
            Idade = idadeInformada;
            Universo = universoInformado;
        }
    }
}