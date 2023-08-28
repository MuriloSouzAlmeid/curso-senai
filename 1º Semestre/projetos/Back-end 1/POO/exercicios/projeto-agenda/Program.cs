using projeto_agenda;

Agenda agenda = new Agenda();


string opcaoMenu = "";

do{

    Console.Clear();
    Console.WriteLine($"\nAgenda de Contatos");
    agenda.TotalContatos();
Console.WriteLine(@$"
Escolha entre:

[1] Adicionar Contato
[2] Listar Contatos
[3] Apagar Contato
[0] Fechar Agenda");
    opcaoMenu = Console.ReadLine()!;

    switch(opcaoMenu){
        case "1":
            string opcaoContato = "";

            Console.WriteLine($"\nQual o tipo de contato que será adicionado:");
            Console.WriteLine($"\n[1] Contato Pessoal");
            Console.WriteLine($"[2] Contato Comercial");
            Console.WriteLine($"[3] Retornar ao menu");
            opcaoContato = Console.ReadLine()!;

                switch(opcaoContato){
                    case "1":
                        ContatoPessoal cp = new ContatoPessoal();

                        Console.WriteLine($"\nInforme o nome do contato:");
                        cp.Nome = Console.ReadLine()!.ToUpper();

                        Console.WriteLine($"\nInforme o núemro de telefone do contato:");
                        cp.Telefone = Console.ReadLine()!;

                        Console.WriteLine($"\nInforme o emai do contato:");
                        cp.Email = Console.ReadLine()!;
                        
                        Console.WriteLine($"\nInforme o CPF do contato já com a máscara: (apenas números)");
                        cp.ValidarCpf(Console.ReadLine()!);

                        agenda.AdicionarContato(cp);

                        break;

                    case "2":
                        ContatoComercial cc = new ContatoComercial();

                        Console.WriteLine($"\nInforme o nome do contato:");
                        cc.Nome = Console.ReadLine()!;

                        Console.WriteLine($"\nInforme o núemro de telefone do contato:");
                        cc.Telefone = Console.ReadLine()!;

                        Console.WriteLine($"\nInforme o emai do contato:");
                        cc.Email = Console.ReadLine()!;
                        
                        Console.WriteLine($"\nInforme o CNPJ do contato: (apenas númerosh)");
                        cc.ValidarCnpj(Console.ReadLine()!);

                        agenda.AdicionarContato(cc);
                        break;

                    case "3":
                        break;    

                    default:
                        Console.WriteLine($"\nOpção Inválida");
                        break;
                }
            break;

        case "2":
            agenda.ListarContatos();
            break;
        
        case "0":
            Console.WriteLine($"\nPressione qualquer tecla para finalizar o programa:");
            Console.ReadLine();
            Environment.Exit(0);
            break;
        
        default:
            Console.WriteLine($"\nOpção informada inválida.");
            break;
    }

    Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu inicial:");
    Console.ReadLine();

}while(opcaoMenu != "0");

