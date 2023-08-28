using mensalidade_escolar;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        // Funções =========================================================================================================================

        // Verificar Sim ou Não ----------------------------------------------------------------------------------------------------

        static string VerificaEscolha(string escolha){
            while((escolha != "S" && escolha != "N") || escolha == ""){
                Console.WriteLine($"Opção informada inválida, escolha entre (s) para sim ou (n) para não:");
                escolha = Console.ReadLine()!.ToUpper();
            }
            return escolha;
        }

        // Finalizar o Programa ---------------------------------------------------------------------------------------------------

        static void FinalizaPrograma(Aluno aluno){
            Console.WriteLine($"\nOk {aluno.nome}, o programa será encerrado agora.");
            Console.WriteLine($"Pressione ENTER para continuar:");
            Console.ReadLine();
            Environment.Exit(0);
        }

        // Menu de Opções ----------------------------------------------------------------------------------------------------------
        static void OpcoesMenu(Aluno aluno){
            Console.Clear();
            Console.WriteLine($"Escolha ente as opções abaixo:");
            Console.WriteLine($"(1) -> Vizualizar Média Final");
            Console.WriteLine($"(2) -> Verificar Valor da Mensalidade");
            Console.WriteLine($"(0) -> Finalizar Programa");
            string escolhaMenu = Console.ReadLine()!;

            while((escolhaMenu != "1" && escolhaMenu != "2" && escolhaMenu != "0") || escolhaMenu == ""){
                Console.WriteLine($"\nOpção informada inválida, escolha entre as opções disponíveis acima:");
                escolhaMenu = Console.ReadLine()!;
            }

            switch(escolhaMenu){
                case "1":
                    aluno.VerMediaFinal();
                    break;
                
                case "2":
                    Console.WriteLine($"\nO valor de mensalidade a ser pago é: {aluno.VerMensalidade().ToString("C", new CultureInfo("pt-br"))}");
                    break;
                
                case "0":
                    FinalizaPrograma(aluno);
                    break;
            }
            
        }

        // =================================================================================================================================

        Console.Clear();
        Console.WriteLine("\nSistema deCadastro de Alunos");

        Console.WriteLine($"\nInforme qual o nome do aluno:");
        string nome = Console.ReadLine()!;

        Console.WriteLine($"\nInforme qual curso o aluno está matriculado:");
        string curso = Console.ReadLine()!;

        Console.WriteLine($"\nInforme a idade do aluno:");
        int idade = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nInforme o RG do aluno: (exemplo 000.000.000-00)");
        string rg = Console.ReadLine()!;

        Console.WriteLine($"\nInforme se o aluno é bolsista: (s/n)");
        string respostaBolsista = Console.ReadLine()!.ToUpper();
        respostaBolsista = VerificaEscolha(respostaBolsista);

        // bool bolsista = (respostaBolsista == "S") ? true : false;
        bool bolsista = (respostaBolsista == "S");

        Console.WriteLine($"\nInforme a média final alcançada pelo aluno:");
        float mediaFinal = float.Parse(Console.ReadLine()!);

        Console.WriteLine($"\nInforme o valor da mensalidade do curso:");
        float valorMensalidade = float.Parse(Console.ReadLine()!);

        Aluno a1 = new Aluno(nome, curso, idade, rg, bolsista, mediaFinal, valorMensalidade);
        
        Console.WriteLine($"\nCadastro de aluno realizado com SUCESSO!"); 

        Console.WriteLine($"Pressione ENTER para continuar...");
        Console.ReadLine();

        string respostaContinuar = "";

        do{
            OpcoesMenu(a1);
            Console.WriteLine($"\neseja retornar ao Menu de Opções: (s/n)");
            respostaContinuar = Console.ReadLine()!.ToUpper();
            respostaContinuar = VerificaEscolha(respostaContinuar);
        } while(respostaContinuar == "S");

        FinalizaPrograma(a1);
    }
}