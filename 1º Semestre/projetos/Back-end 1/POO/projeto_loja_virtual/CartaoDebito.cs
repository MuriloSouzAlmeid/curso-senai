using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_loja_virtual
{
    public class Debito : Cartao
    {
        MenuClass menuCartao = new MenuClass();
        public double Saldo {get; private set;} = 2000;
        public override void Pagar(bool cartaoCardastrado, Debito pagamentoDebito, CartaoCredito pagamentoCredito)
        {
            if (Saldo < ValorInicial)
            {
                Console.WriteLine($"\nSaldo insuficiente para a compra.");
                Cancelar();
                menuCartao.MenuInicial(this.ValorInicial, cartaoCardastrado, pagamentoDebito, pagamentoCredito);
            }
            else
            {
                this.ValorFinal = this.ValorInicial;
                Console.WriteLine($"\nO valor da compra a ser pago será de: {this.ValorFinal:C2} e será debitado em sua conta corrente.");
                Saldo = Saldo - ValorFinal;
            }

        }
    }
}