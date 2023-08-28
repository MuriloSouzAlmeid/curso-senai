using utilizando_celular;
using utilizando_celular.operacoes_gerais;

namespace utilizando_celular
{
    public class Menu
    {
        public string[] OpcoesMenu = new string[3] {"l", "m", "d"}; 
        public string[] OpcoesSimOuNao = new string[2] {"s", "n"};
        public string OpcaoEscolhida;

        public void MostrarMenuOpcoes(Celular celular, Verificador verificaResposta){
            string respostaContinuar = "";
            Console.WriteLine($"Menu de Ações do {celular.Modelo}:");
            Console.WriteLine($"[L] -> Fazer uma Ligação.");
            Console.WriteLine($"[M] -> Enviar uma Mensagem.");
            Console.WriteLine($"[D] -> Desligar o Celular.");
            this.OpcaoEscolhida = Console.ReadLine()!.ToLower();
            this.OpcaoEscolhida = verificaResposta.VerificarResposta(OpcaoEscolhida, OpcoesMenu);

            switch(this.OpcaoEscolhida){
                case "l":
                    do{
                        celular.FazerLigacao();
                        Console.WriteLine($"\nDeseja fazer uma nova ligação: (s/n)");
                        respostaContinuar = Console.ReadLine()!.ToLower();
                        respostaContinuar = verificaResposta.VerificarResposta(respostaContinuar, OpcoesSimOuNao);
                    }while(respostaContinuar == "s");
                    Console.WriteLine($"\nPressione ENTER para retornar ao menu de ações:");
                    Console.ReadLine();
                    break;

                case "m":
                    do{
                        celular.EnviarMensagem();
                        Console.WriteLine($"\nDeseja enviar uma nova mensagem: (s/n)");
                        respostaContinuar = Console.ReadLine()!.ToLower();
                        respostaContinuar = verificaResposta.VerificarResposta(respostaContinuar, OpcoesSimOuNao);
                    }while(respostaContinuar == "s");
                    Console.WriteLine($"\nPressione ENTER para retornar ao menu de ações:");
                    Console.ReadLine();
                    break;

                case "d":
                    Console.WriteLine($"{celular.Desligar()}");
                    break;
            }
        }
    }
}