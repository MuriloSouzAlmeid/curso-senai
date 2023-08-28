using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Projeto_loja_virtual
{
    public class CartaoCredito : Cartao
    {
        MenuClass novoMenu = new MenuClass();
        // Atributos
        private float Limite = 2000;
        public float ValorParcela;

        public int Parcelas;

        // Métodos

        // Método para exibir o limite do cartão de crédito
        public override void Pagar(bool cartaoCardastrado, Debito pagamentoDebito, CartaoCredito pagamentoCredito)
        {
            if (this.ValorInicial > this.Limite)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nLimite do cartão excedido");
                    Console.ResetColor();

                    Cancelar();
                    novoMenu.MenuInicial(this.ValorInicial, cartaoCardastrado, pagamentoDebito, pagamentoCredito);

                }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"Informe em quantas parcelas deseja pagar o produto: (máximo de 12 parcelas)");
            Console.WriteLine(@$"
            [1x] - Sem juros
            [2x - 6x] - Juros de 5%
            [7x - 12x] - Juros de 8%
            ");

            this.Parcelas = int.Parse(Console.ReadLine()!);

            while (this.Parcelas > 12 || this.Parcelas <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Número de parcelas inválido. Digite entre 1 ou 12 parcelas");
                this.Parcelas = int.Parse(Console.ReadLine()!);
                Console.ResetColor();
            }


            do
            {
                if (this.Parcelas == 1)
                {
                    this.ValorParcela = this.ValorInicial / this.Parcelas;
                    ValorFinal = this.ValorParcela;

                }
                else if (this.Parcelas <= 6)
                {
                    this.ValorParcela = this.ValorInicial / this.Parcelas;
                    this.ValorFinal = this.ValorParcela * 1.05d;

                }
                else if (this.Parcelas > 6)
                {
                    this.ValorParcela = this.ValorInicial / this.Parcelas;
                    this.ValorFinal = this.ValorParcela * 1.08d;

                }
                else
                {
                    while (this.Parcelas > 12 || this.Parcelas <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Número de parcelas inválido. Digite entre 1 ou 12 parcelas");
                        this.Parcelas = int.Parse(Console.ReadLine()!);
                        Console.ResetColor();
                    }
                }
            } while (this.ValorFinal > this.Limite);


            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();

            if (this.Parcelas > 1)
            {
                Console.WriteLine($"\nTotal: {ValorFinal:C2} de {this.Parcelas}x com juros.");
            }
            else
            {
                Console.WriteLine($"\nTotal: {ValorFinal:C2} de {this.Parcelas}x sem juros.");
            }

            Console.ResetColor();
        }
    }
}
