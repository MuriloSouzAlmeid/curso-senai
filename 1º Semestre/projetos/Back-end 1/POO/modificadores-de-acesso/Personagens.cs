namespace Personagens{

    // Classe com atributos públicos
    public class Protagonista{
        public string nome;
        public int idade;
        public string universo;

        public Protagonista(string nomeInformado, int idadeInformada, string universoInformado){
            nome = nomeInformado;
            idade = idadeInformada;
            universo = universoInformado;
        }
    }

    // Classe com atributos privados
    public class Antagonista{
        private string nome;
        private int idade;
        private string universo;

        private Antagonista(string nomeInformado, int idadeInformada, string universoInformado){
            nome = nomeInformado;
            idade = idadeInformada;
            universo = universoInformado;
        }
    }
}