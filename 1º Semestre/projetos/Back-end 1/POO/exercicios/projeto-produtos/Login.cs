namespace projeto_produtos
{
    public class Login
    {
        // Atributos
        public bool Logado { get; set; } = false;
        public int UsuariosCadastrados { get; private set; }

        // Construtor
        public Login()
        {
            int codeMax = 1;
            string respostaMenu = "";
            Usuario usuario = new Usuario();
            Produto produto = new Produto();
            Marca marca = new Marca();
            int produtosCadastrados = 0;
            int marcasCadastradas = 0;
            do
            {
                Console.Clear();
                Console.WriteLine($"\nSeja Bem-Vindo ao programa de Cadastro de Produtos\n");

                // Cadastrando um Usuário

                if (this.UsuariosCadastrados == 0)
                {
                    Console.WriteLine($"\nNão há usuários Cadastrados no programa.");
                }
                else
                {
                    usuario.ListarUsuarios();
                }

                Console.WriteLine($"\nEscolha Entre:");
                Console.WriteLine($"\n[1] Cadastar Usuário");

                if (this.UsuariosCadastrados > 0)
                {
                    Console.WriteLine($"[2] Remover Usuário");
                    Console.WriteLine($"[3] Logar Usuário");
                }
                Console.WriteLine($"[0] Finalizar Programa");

                respostaMenu = Console.ReadLine()!;

                switch (respostaMenu)
                {
                    // Cadastro de usuário
                    case "1":
                        Usuario usuarioCadastrado = new Usuario();
                        if (usuario.Cadastrar(usuarioCadastrado, codeMax))
                        {
                            codeMax++;
                            this.UsuariosCadastrados++;
                            Console.WriteLine($"\nUsuário Cadastrado com Sucesso");
                        }
                        else
                        {
                            Console.WriteLine($"\nUm ou mais campos não foram preenchidos, tente novamente!");
                        }
                        Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu inicial:");
                        Console.ReadKey();
                        break;

                    // Remoção de Usuário
                    case "2":
                        if (usuario.Deletar())
                        {
                            Console.WriteLine($"\nUsuário Removido com Sucesso");
                            this.UsuariosCadastrados--;
                        }
                        Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu inicial:");
                        Console.ReadKey();
                        break;

                    // Login de Usuário
                    case "3":
                        // Logando o Usuário
                        if (this.Logar(usuario))
                        {
                            Console.WriteLine($"\nPressione qualquer tecla para ser redirecionado ao Menu de Produtos");
                            Console.ReadKey();
                            // Menu de Produtos
                            string escolhaMenu = "";
                            bool resultadoDeslogar = false;
                            string codigoMarcaNova = "";
                            do
                            {
                                if (produtosCadastrados > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\nUsuário Logado no momento: {usuario.Nome}");

                                    Console.WriteLine($"\nMenu de Produtos:\n");
                                    Console.WriteLine($"Escolha entre:");
                                    Console.WriteLine($"\nOpções Produtos:");
                                    Console.WriteLine($"[1] Cadastar Produto");
                                    Console.WriteLine($"[2] Listar Produtos");
                                    Console.WriteLine($"[3] Remover Produto");
                                    Console.WriteLine($"\nOpções Marcas:");
                                    Console.WriteLine($"[4] Cadastrar Marca");
                                    Console.WriteLine($"[5] Listar Marcas");
                                    Console.WriteLine($"[6] Remover Marca");
                                    Console.WriteLine($"\n[0] Deslogar Usuário");
                                    escolhaMenu = Console.ReadLine()!;

                                    switch (escolhaMenu)
                                    {
                                        case "1":
                                            Console.WriteLine($"\nCadastro de Produto");
                                            Produto produtoCadastro = new Produto();
                                            string usuarioQueCadastrou = usuario.Nome;
                                            if (produto.CadastarProduto(produtoCadastro, usuarioQueCadastrou, marca))
                                            {
                                                Console.WriteLine($"\nProduto Cadastrado com Sucesso.");
                                                produtosCadastrados++;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\nFalha ao cadastrar novo produto, um ou mais campos foram preenchidos incorretamente. Tente Novamente");
                                                Console.ResetColor();
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "2":
                                            produto.ListarProdutos();
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "3":
                                            Console.WriteLine($"\nInforme o código do produto a ser deletado:");
                                            string codigoInformado = Console.ReadLine()!;
                                            if (produto.DeletarProduto(codigoInformado, usuario) == $"\nProduto Removido com Sucesso!")
                                            {
                                                produtosCadastrados--;
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "4":
                                            Console.WriteLine($"\nInforme o código da marca a ser cadastrada:");
                                            codigoMarcaNova = Console.ReadLine()!;
                                            if (marca.Cadastrar(codigoMarcaNova, usuario.Nome))
                                            {
                                                Console.WriteLine($"\nMarca cadastrada com Sucesso!");
                                                marcasCadastradas++;
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "5":
                                            marca.ListarMarcas();
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "6":
                                            if(marca.DeletarMarca()){
                                                Console.WriteLine($"\nMarca Removida com Sucesso!");
                                                marcasCadastradas--;   
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "0":
                                            resultadoDeslogar = this.Deslogar();
                                            if (resultadoDeslogar)
                                            {
                                                Console.WriteLine($"\nOk, pressione qualquer tecla para Deslogar o usuário:");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nOk, pressione qualquer tecla para retornar ao menu de Produtos:");
                                                Console.ReadKey();
                                            }
                                            break;

                                        default:
                                            break;
                                    }
                                }
                                else if (marcasCadastradas > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\nUsuário Logado no momento: {usuario.Nome}");

                                    Console.WriteLine($"\nMenu de Produtos:\n");
                                    Console.WriteLine($"Escolha entre:");
                                    Console.WriteLine($"\nOpções Produtos:");
                                    Console.WriteLine($"[1] Cadastar Produto");
                                    Console.WriteLine($"\nOpções Marcas:");
                                    Console.WriteLine($"[2] Cadastrar Marca");
                                    Console.WriteLine($"[3] Listar Marcas");
                                    Console.WriteLine($"[4] Remover Marca");
                                    Console.WriteLine($"\n[0] Deslogar Usuário");
                                    escolhaMenu = Console.ReadLine()!;

                                    switch (escolhaMenu)
                                    {
                                        case "1":
                                            Console.WriteLine($"\nCadastro de Produto");
                                            Produto produtoCadastro = new Produto();
                                            if (produto.CadastarProduto(produtoCadastro, usuario.Nome, marca))
                                            {
                                                Console.WriteLine($"\nProduto Cadastrado com Sucesso.");
                                                produtosCadastrados++;
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\nFalha ao cadastrar novo produto, um ou mais campos foram preenchidos incorretamente. Tente Novamente");
                                                Console.ResetColor();
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "2":
                                            Console.WriteLine($"\nInforme o código da marca a ser cadastrada:");
                                            codigoMarcaNova = Console.ReadLine()!;
                                            if (marca.Cadastrar(codigoMarcaNova, usuario.Nome))
                                            {
                                                Console.WriteLine($"\nMarca cadastrada com Sucesso!");
                                                marcasCadastradas++;
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "3":
                                            marca.ListarMarcas();
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "4":
                                            if(marca.DeletarMarca()){
                                                Console.WriteLine($"\nMarca Removida com Sucesso!");
                                                marcasCadastradas--;   
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "0":
                                            resultadoDeslogar = this.Deslogar();
                                            if (resultadoDeslogar)
                                            {
                                                Console.WriteLine($"\nOk, pressione qualquer tecla para Deslogar o usuário:");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nOk, pressione qualquer tecla para retornar ao menu de Produtos:");
                                                Console.ReadKey();
                                            }
                                            break;

                                        default:
                                            break;
                                    }
                                }

                                else
                                {

                                    Console.Clear();
                                    Console.WriteLine($"\nUsuário Logado no momento: {usuario.Nome}");

                                    Console.WriteLine($"\nMenu de Produtos:\n");
                                    Console.WriteLine($"Escolha entre:");
                                    Console.WriteLine($"\nOpções Produtos:");
                                    Console.WriteLine($"[1] Cadastar Produto");
                                    Console.WriteLine($"\nOpções Marcas:");
                                    Console.WriteLine($"[2] Cadastrar Marca");
                                    Console.WriteLine($"\n[0] Deslogar Usuário");
                                    escolhaMenu = Console.ReadLine()!;

                                    switch (escolhaMenu)
                                    {
                                        case "1":
                                            int qtdMarcasAntiga = marca.ListaDeMarcas().Count;
                                            Console.WriteLine($"\nCadastro de Produto");
                                            Produto produtoCadastro = new Produto();
                                            if (produto.CadastarProduto(produtoCadastro, usuario.Nome, marca))
                                            {
                                                Console.WriteLine($"\nProduto Cadastrado com Sucesso.");
                                                produtosCadastrados++;
                                                if(qtdMarcasAntiga < marca.ListaDeMarcas().Count){
                                                    marcasCadastradas++;
                                                }
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\nFalha ao cadastrar novo produto, um ou mais campos foram preenchidos incorretamente. Tente Novamente");
                                                Console.ResetColor();
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "2":
                                            Console.WriteLine($"\nInforme o código da marca a ser cadastrada:");
                                            codigoMarcaNova = Console.ReadLine()!;
                                            if (marca.Cadastrar(codigoMarcaNova, usuario.Nome))
                                            {
                                                Console.WriteLine($"\nMarca cadastrada com Sucesso!");
                                                marcasCadastradas++;
                                            }
                                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu de Produtos:");
                                            Console.ReadKey();
                                            break;

                                        case "0":
                                            resultadoDeslogar = this.Deslogar();
                                            if (resultadoDeslogar)
                                            {
                                                Console.WriteLine($"\nOk, pressione qualquer tecla para Deslogar o usuário:");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine($"\nOk, pressione qualquer tecla para retornar ao menu de Produtos:");
                                                Console.ReadKey();
                                            }
                                            break;

                                        default:
                                            break;
                                    }
                                }
                            } while (resultadoDeslogar == false);
                        }

                        else
                        {
                            Console.WriteLine($"\nPressione qualquer tecla para retornar ao menu inicial:");
                            Console.ReadKey();
                        }
                        break;

                    case "0":
                        Console.WriteLine($"\nOk, Pressione qualquer tecla para finalizar o programa:");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine($"\nOpção informada inválida. Pressione qualquer tecla para voltar ao menu:");
                        Console.ReadKey();
                        break;
                }
            } while (respostaMenu != "0");
        }

        // Métodos
        public bool Logar(Usuario usuario)
        {
            Console.WriteLine($"\nSelecione o usuário que deseja se logar pelo código:");
            string codigoInformado = Console.ReadLine()!;

            if (usuario.VerificarUsuario(codigoInformado) == false)
            {
                Console.WriteLine($"\nCódigo informado não existe. Tente novamente!");
                return false;
            }

            if (usuario.VerificarLogin(codigoInformado, usuario))
            {
                Console.WriteLine($"\nUsuário Logado com Sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine($"\nEmail ou Senha informados incorretos!");
                return false;
            }
        }

        public bool Deslogar()
        {
            Console.WriteLine($"\nTem certeza que deseja Deslogar seu usuário? (s/n)");
            string respostaDeslogar = Console.ReadLine()!.ToUpper();

            while ((respostaDeslogar != "S" && respostaDeslogar != "N") || respostaDeslogar == "")
            {
                Console.WriteLine($"\nOpção informada inválida. Escolha entre (s) para sim ou (n) para não:");
                respostaDeslogar = Console.ReadLine()!.ToUpper();
            }

            if (respostaDeslogar == "S")
            {
                return true;
            }

            return false;
        }
    }
}