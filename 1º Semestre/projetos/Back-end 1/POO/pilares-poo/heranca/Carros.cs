namespace Carros{
    
    //Classe Pai


    // sealed class Veiculo - caso eu utilize o selead (selado) eu não poderei criar classes herdadas dessa classe
    public class Veiculo{
        public string marca;

        public void Acelerar(string resposta){
            if(resposta == "S"){
                Console.WriteLine("Vrum, Vrum, Vruuuuum!");
            } else{
                Console.WriteLine("Literalmente parado.");
            }
        }
    }

    // Classe Filho
    public class Carro : Veiculo{
        public string modelo;
        public int ano;

        // Pela classe Carro ser herdeira (filha) da classe Veívulo ela também herda seus atributos e seus métodos
        public Carro(string marcaInformada, string modeloInformado, int anoInformado){
            marca = marcaInformada;
            modelo = modeloInformado;
            ano = anoInformado;
        }
    }
}