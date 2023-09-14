using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        //método que logará usuário por seu email e senha
        Usuario Login(string email, string senha);

        //método que cadastra um novo usuário
        void CadastrarUsuario(Usuario novoUsuario);
    }
}
