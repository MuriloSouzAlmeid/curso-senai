namespace Projeto_loja_virtual{
    public abstract class Cartao : Pagamento{
        // Atributos
        public string Bandeira {get; set;} = "";
        public string NumeroCartao {get; set;} = "";
        public string Titular {get; set;} = "";
        public string Cvv {get; set;} = "";

        // Métodos
        public abstract void Pagar(bool cartaoCardastrado, Debito pagamentoDebito, CartaoCredito pagamentoCredito);

        public string SalvarCartao(string bandeira, string numeroCartao, string titular, string cvv){
            this.Bandeira = bandeira;
            this.NumeroCartao = numeroCartao;
            this.Titular = titular;
            this.Cvv = cvv;

            return   $"\nCartão cadastrado com sucesso!";
        }
    }
}