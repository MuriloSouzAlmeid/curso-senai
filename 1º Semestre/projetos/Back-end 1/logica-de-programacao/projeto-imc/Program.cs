// Programa IMC 

// Faça um Programa para calcular o IMC de uma pessoa recebendo os dados no console, ao final exiba a mensagem no console

// Início =================================================================================================

// Define uma cor de fundo
Console.ForegroundColor = ConsoleColor.Cyan;

// a escrita \n pula uma linha
// O símbolo @ serve para formatação da linha na qual vai obedecer os espaçamentos
Console.WriteLine(@$"

                  '
            *          .          *       '       *             .  
              *                *          *   '*               *
    *                  .             *
               *          .                 *

██████╗░██████╗░░█████╗░░░░░░██╗███████╗████████╗░█████╗░  ██╗███╗░░░███╗░█████╗░
██╔══██╗██╔══██╗██╔══██╗░░░░░██║██╔════╝╚══██╔══╝██╔══██╗  ██║████╗░████║██╔══██╗
██████╔╝██████╔╝██║░░██║░░░░░██║█████╗░░░░░██║░░░██║░░██║  ██║██╔████╔██║██║░░╚═╝
██╔═══╝░██╔══██╗██║░░██║██╗░░██║██╔══╝░░░░░██║░░░██║░░██║  ██║██║╚██╔╝██║██║░░██╗
██║░░░░░██║░░██║╚█████╔╝╚█████╔╝███████╗░░░██║░░░╚█████╔╝  ██║██║░╚═╝░██║╚█████╔╝
╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░╚════╝░╚══════╝░░░╚═╝░░░░╚════╝░  ╚═╝╚═╝░░░░░╚═╝░╚════╝░
                  

         .                      .
         .                      ;
         :                  - --+- -    *              *
         !           .          !
         |        .             .             *                 *
         |_         +
      ,  | `.
--- --+-<#>-+- ---  --  -      *      '          *           ,           *
      `._|_,'
         T
         |               *              *                 *         *
         !
         :         . :   .             *     .            .              *
         .       *             

");

// Volta a cor de fundo para as CompressedStack originais
Console.ResetColor();

// Entradas ==============================================================================================

Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine(@$"---------------- Informe o nome do paciente -----------------");
// Método para ler o que foi informado pelo teclado
string nome = Console.ReadLine();
Console.WriteLine("\n");

Console.WriteLine(@$"------------- Informe o peso atual do paciente --------------");
// Método para converter tipos de variáveis em números sendo tipo_que_vc_que.Parse()
float peso = float.Parse(Console.ReadLine());
Console.WriteLine("\n");

Console.WriteLine(@$"-------------- Informe a altura do paciente ------------------");
float altura = float.Parse(Console.ReadLine());
Console.WriteLine("\n");
Console.ResetColor();

// Processamento ==========================================================================================

// Math.Pow é um método utilizado para potenciação sendo assim (tipo de variável)Math.Pow(valor, quantas vezes)
float imc = peso / ((float)Math.Pow(altura,2));

// Saída =================================================================================================

Console.ForegroundColor = ConsoleColor.Green;

// Métod por concatenação
// Console.WriteLine("O IMC do paciente " + nome + " é " + Math.Round(imc,2));

// Método por interpolação
Console.WriteLine(@$"
=======================================================================
     | O IMC do paciente {nome} é igual a: {Math.Round(imc,2)} |
=======================================================================
");

Console.ResetColor();

// Fim =====================================================================================================