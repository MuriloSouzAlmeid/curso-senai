namespace projeto_produtos
{
    public class Usuario
    {
        // Atributos
        public string? Codigo { get; private set; }
        public int GeradorCodigo { get; private set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public string? Senha { get; private set; }
        public DateTime DataUsuario { get; private set; }

        List<Usuario> listaDeUsuarios = new List<Usuario>();

        // Métodos
        public bool Cadastrar(Usuario _usuario, int _codigoAtual)
        {
            Console.WriteLine($"\nInforme seu nome completo:");
            string nomeInformado = Console.ReadLine()!;

            Console.WriteLine($"\nInforme seu email:");
            string emailInformado = Console.ReadLine()!;

            Console.WriteLine($"\nInforme uma senha:");
            string senhaInformada = Console.ReadLine()!;

            if (nomeInformado == "" || emailInformado == "" || senhaInformada == "")
            {
                return false;
            }
            else
            {
                _usuario.Nome = nomeInformado;
                _usuario.Email = emailInformado;
                _usuario.Senha = senhaInformada;
                _usuario.Codigo = _codigoAtual.ToString();

                _usuario.DataUsuario = DateTime.Now;

                listaDeUsuarios.Add(_usuario);

                return true;
            }
        }

        public void ListarUsuarios()
        {
            Console.WriteLine($"\nLista de Usuários Cadastrados:");

            foreach (Usuario u in listaDeUsuarios)
            {
                Console.WriteLine($"---------------------------------------------------------------");
                Console.WriteLine($"Código: {u.Codigo}.    Nome: {u.Nome}.");
            }
            Console.WriteLine($"---------------------------------------------------------------");
        }

        public bool VerificarUsuario(string _codigo)
        {
            bool usuarioExiste = false;

            foreach (Usuario u in listaDeUsuarios)
            {
                if (_codigo == u.Codigo)
                {
                    usuarioExiste = true;
                }
            }

            return usuarioExiste;
        }

        public bool Deletar()
        {
            Console.WriteLine($"\nSelecione o usuário que deseja remover pelo código:");
            string codigoInformado = Console.ReadLine()!;

            if (this.VerificarUsuario(codigoInformado) == false)
            {
                Console.WriteLine($"\nCódigo informado não existe. Tente novamente!");
                return false;
            }

            Usuario objetoEncontrado = listaDeUsuarios.Find(x => x.Codigo == codigoInformado)!;

            Console.WriteLine($"\nInforme a senha do usuário seleciondo para confirmar a operação:");
            string senhaInformada = Console.ReadLine()!;

            if (senhaInformada == objetoEncontrado.Senha)
            {
                listaDeUsuarios.Remove(objetoEncontrado);
                return true;
            }
            else
            {
                Console.WriteLine($"\nSenha informada incorreta, tente novamente!");
                return false;
            }
        }

        public bool VerificarLogin(string _codigo, Usuario _usuario)
        {
            Usuario usuarioBuscado = listaDeUsuarios.Find(x => x.Codigo == _codigo)!;

            _usuario.Nome = usuarioBuscado.Nome;

            Console.WriteLine($"\nInforme o email do usuário selecionado:");
            string emailInformado = Console.ReadLine()!;

            Console.WriteLine($"\nInforme a senha do usuário selecionado:");
            string senhaInformada = Console.ReadLine()!;

            if ((emailInformado == usuarioBuscado.Email) && (senhaInformada == usuarioBuscado.Senha))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}