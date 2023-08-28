namespace calculadora{
    public class Calculadora{
        public string operacao;
        public float n1;
        public float n2;

        public Calculadora(string operacaoInformada, float n1Informado, float n2Informado){
            operacao = operacaoInformada;
            n1 = n1Informado;
            n2 = n2Informado;
        }

        // this. Acessa propriedades dentro de sua prórpia classe
        public float EfetuarConta(){
            float resultado = 0;
            switch(this.operacao){
                case "+":
                    resultado = this.n1 + this.n2;
                    break;

                case "-":
                    resultado = this.n1 - this.n2;
                    break;

                case "x":
                    resultado = this.n1 * this.n2;
                    break;

                case ":":
                    resultado = this.n1 / this.n2;
                    break;
            }
            return resultado;
        }
    }
}