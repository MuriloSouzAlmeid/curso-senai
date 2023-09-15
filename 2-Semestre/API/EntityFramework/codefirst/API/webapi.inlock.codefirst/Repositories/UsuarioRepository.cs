using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Utils;

namespace webapi.inlock.codefirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //cria uma variável privada de somente leitura (injeção de dependência)
        private readonly InLockContext ctx;
        //instanciando o objeto da Context
        public UsuarioRepository()
        {
            ctx = new InLockContext();
        }
        public void CadastrarUsuario(Usuario novoUsuario)
        {
            try
            {
                //troca a senha informada por uma hash criptografada
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha);

                ctx.Usuarios.Add(novoUsuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                //gera uma exceção automática
                throw;
            }
        }

        public Usuario Login(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool senhaValida = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if (senhaValida)
                    {
                        return usuarioBuscado;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
