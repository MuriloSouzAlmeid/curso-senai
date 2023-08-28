using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Projeto_loja_virtual
{
    public class MenuClass
    {
        public void MenuInicial(float valorInformado, bool cartaoCardastrado, Debito pagamentoDebito, CartaoCredito pagamentoCredito)
        {
            string resposta = "";
            string input = "";
            bool sair = false;
            // INICIO


            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"            === Bem-vindo ===");
            Console.ResetColor();
            Console.WriteLine($"\nValor da compra: {valorInformado:C2}\n");
            Thread.Sleep(1000);

            do
            {
                Console.WriteLine(@$"Escolha a forma de pagamento da compra:
                
            [1] Boleto
            [2] Cartão 
            [3] Sair");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.ResetColor();

                resposta = Console.ReadLine()!;
                switch (resposta)
                {

                    case "1":
                        Console.WriteLine($"\nValor da compra: {valorInformado}");
                        Boleto pagamentoBoleto = new Boleto();
                        Console.Clear();
                        //Boleto

                        do
                        {
                            pagamentoBoleto.ValorInicial = valorInformado;
                            pagamentoBoleto.Registrar();
                            Console.WriteLine(@$"
            [1] Finalizar compra
            [2] Cancelar Operação
                    ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine($"Insira a opção desejada:");
                            Console.ResetColor();
                            input = Console.ReadLine()!;
                            switch (input)
                            {
                                case "1":
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nCompra Finalizada... Seu boleto vence no dia {pagamentoBoleto.GerarData()}");
                                    Console.Beep(2000, 2000);
                                    Console.ResetColor();
                                    Environment.Exit(0);
                                    break;

                                case "2":
                                    pagamentoBoleto.Cancelar();
                                    MenuInicial(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                                    Console.Clear();
                                    break;

                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Clear();
                                    Console.WriteLine($"Opção inválida.");
                                    Console.ReadLine();

                                    Console.ResetColor();
                                    break;
                            }

                        } while (input != "2");
                        break;
                    case "2":
                        Console.Clear();

                        MenuCartao(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);

                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nSair do programa? S/N\n");
                        Console.ResetColor();
                        resposta = Console.ReadLine()!.ToUpper();
                        if (resposta == "S")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Finalizando o programa...");
                            Console.Beep(2000, 2000);
                            Console.ResetColor();
                            sair = true;
                            Environment.Exit(0);
                        }
                        else
                        {
                            sair = false;
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine($"Valor inválido, tente novamente...");
                        Console.ResetColor();
                        break;
                }
            } while (!sair);

            // FIM
        }

        public void MenuCartao(float valorInformado, bool cartaoCardastrado, Debito pagamentoDebito, CartaoCredito pagamentoCredito)
        {
            string resposta = "";
            string input = "";
            string bandeira = "";
            string numeroCartao = "";
            string titular = "";
            string cvv = "";

            do
            {
                if (cartaoCardastrado == false)
                {
                    Console.WriteLine($"\nCadastro do cartão:");

                    Console.WriteLine($"\nQual a bandeira do cartão:");
                    bandeira = Console.ReadLine()!;

                    while (bandeira == "")
                    {
                        Console.WriteLine($"Campo digitado inválido. Digite um valor válido para a bandeira do cartão:");
                        bandeira = Console.ReadLine()!;
                    }

                    Console.WriteLine($"\nDigite o número do cartão:");
                    numeroCartao = Console.ReadLine()!;

                    while (numeroCartao == "")
                    {
                        Console.WriteLine($"Campo digitado inválido. Digite um valor válido para o número do cartão:");
                        numeroCartao = Console.ReadLine()!;
                    }

                    Console.WriteLine($"\nInsira o nome do titular do cartão:");
                    titular = Console.ReadLine()!;

                    while (titular == "")
                    {
                        Console.WriteLine($"Campo digitado inválido. Digite um valor válido para o titular do cartão:");
                        titular = Console.ReadLine()!;
                    }

                    Console.WriteLine($"\nInforme o CVV do cartão:");
                    cvv = Console.ReadLine()!;

                    while (cvv == "")
                    {
                        Console.WriteLine($"Campo digitado inválido. Digite um valor válido para o CVV do cartão:");
                        cvv = Console.ReadLine()!;
                    }

                    Console.WriteLine(pagamentoDebito.SalvarCartao(bandeira, numeroCartao, titular, cvv));
                    pagamentoCredito.SalvarCartao(bandeira, numeroCartao, titular, cvv);
                    cartaoCardastrado = true;
                }
                Console.Clear();
                Console.WriteLine($"\nValor da compra: {valorInformado:C2}\n");
                Console.WriteLine($"\nDados do cortão cadastrado:\n");
                Console.WriteLine($"Titular do cartão: {pagamentoDebito.Titular}");
                Console.WriteLine($"Bandeira do cartão: {pagamentoDebito.Bandeira}");
                Console.WriteLine($"Número do cartão: {pagamentoDebito.NumeroCartao}");
                Console.WriteLine($"Bandeira do cartão: {pagamentoDebito.Cvv}\n");
                Console.WriteLine(@$"Escolha dentre as opções abaixo:

                [1] Pagar com o Cartão de Débito
                [2] Pagar com o Cartão de Crédito
                [3] Voltar ao Menu de Cartão
                ");
                resposta = Console.ReadLine()!;
                switch (resposta)
                {
                    case "1":
                        if (cartaoCardastrado)
                        {
                            pagamentoDebito.Pagar(cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                            do
                            {
                                Console.WriteLine(@$"
                                [1] Finalizar compra
                                [2] Cancelar Operação
                                ");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine($"Insira a opção desejada:");
                                Console.ResetColor();
                                input = Console.ReadLine()!;
                                switch (input)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nCompra Finalizada...");
                                        Console.ResetColor();
                                        Console.Beep(2000, 2000);
                                        // Como ainda n tenho nenhuma váriavel eu n botei pra imprimir o novo saldo ent só ta saindo do programa
                                        Environment.Exit(0);
                                        break;
                                    case "2":
                                        pagamentoDebito.Cancelar();
                                        Console.Clear();
                                        MenuInicial(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                                        break;

                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Console.WriteLine($"Valor inválido, tente novamente...");
                                        Console.ResetColor();
                                        break;
                                }

                            } while (input != "2");
                        }
                        else
                        {
                            Console.WriteLine($"Não há um cartão de débito cadastrado. Pressione ENTER para voltar ao menu de cadastro:");
                            Console.ReadLine();
                            MenuCartao(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                        }

                        break;

                    case "2":

                        //Cartão de Crédito
                        if (cartaoCardastrado)
                        {
                            pagamentoCredito.Pagar(cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                            do
                            {
                                Console.WriteLine(@$"
                        [1] Finalizar compra
                        [2] Cancelar Operação
                        ");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine($"Insira a opção desejada:");
                                Console.ResetColor();
                                input = Console.ReadLine()!;
                                switch (input)
                                {
                                    case "1":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\nCompra Finalizada...");
                                        Console.Beep(2000, 2000);
                                        Console.ResetColor();

                                        // Como ainda n tenho nenhuma váriavel eu n botei pra imprimir o novo saldo ent só ta saindo do programa
                                        Environment.Exit(0);
                                        break;
                                    case "2":
                                        pagamentoCredito.Cancelar();
                                        Console.Clear();
                                        MenuInicial(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Console.WriteLine($"Valor inválido, tente novamente...");
                                        Console.ResetColor();
                                        break;
                                }

                            } while (input != "2");
                        }
                        else
                        {
                            Console.WriteLine($"Não há um cartão de crédito cadastrado. Pressione ENTER para voltar ao menu de cartão:");
                            Console.ReadLine();
                            MenuCartao(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                        }

                        break;

                    case "3":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Cancelando a operação...");
                        Console.WriteLine($"Pressione ENTER para continuar");
                        Console.ReadLine();
                        Console.ResetColor();
                        Console.Clear();
                        MenuInicial(valorInformado, cartaoCardastrado, pagamentoDebito, pagamentoCredito);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine($"Valor inválido, tente novamente...");
                        Console.ResetColor();
                        break;
                }
            } while (resposta != "3");

        }
    }
}