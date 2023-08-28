using Projeto_loja_virtual;

MenuClass MenuPrograma = new MenuClass();
Console.Clear();
Console.WriteLine($"\nInsira o valor da compra:");
            string valorDigitado = Console.ReadLine()!;

            while(valorDigitado == ""){
                Console.WriteLine($"\nValor informado inválido, digite um preço adequado para um produto");
                valorDigitado = Console.ReadLine()!;
            }

            float valorInformado = float.Parse(valorDigitado);

            while(valorInformado <= 0){
                Console.WriteLine($"\nValor informado inválido, digite um preço adequado para um produto");
                valorInformado = float.Parse(Console.ReadLine()!);
            }

Debito pagamentoDebito = new Debito();
pagamentoDebito.ValorInicial = valorInformado;
CartaoCredito pagamentoCredito = new CartaoCredito();
pagamentoCredito.ValorInicial = valorInformado;
bool cartaoCardastrado = false;
MenuPrograma.MenuInicial(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);