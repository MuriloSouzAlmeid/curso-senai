namespace mensalidade_escolar
{
    public class Aluno
    {
        // Atributos
        public string nome;
        public string curso;
        public int idade;
        public string rg;
        public bool bolsista;
        public float mediaFinal;
        public float valorMensalidade;

        // Construtor
        public Aluno(string nomeInformado, string cursoInformado, int idadeInformada, string rgInformado, bool bolsaInformada, float mediaInformada, float valorInformado){
            this.nome = nomeInformado;
            this.curso = cursoInformado;
            this.idade = idadeInformada;
            this.rg = rgInformado;
            this.bolsista = bolsaInformada;
            this.mediaFinal = mediaInformada;
            this.valorMensalidade = valorInformado;
        }

        // Métodos
        public void VerMediaFinal(){
            Console.WriteLine($"\nA média final do aluno {this.nome} é: {this.mediaFinal}");
        }

        public float VerMensalidade(){
            float valorFinal = this.valorMensalidade;
            if(this.bolsista){
                if(this.mediaFinal >= 8){
                    valorFinal = this.valorMensalidade = this.valorMensalidade - (0.5f * this.valorMensalidade);
                } else if(this.mediaFinal >= 6){
                    valorFinal =this.valorMensalidade = this.valorMensalidade - (0.3f * this.valorMensalidade);
                }
            }
            return valorFinal;
        }

    }
}