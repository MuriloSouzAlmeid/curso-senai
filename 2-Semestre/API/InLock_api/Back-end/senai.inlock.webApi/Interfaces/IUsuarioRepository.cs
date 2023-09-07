using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface que contém os métodos e regras de negócios referente ao Login da entidade Estúdio
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método para realizar o login de um usuário e definir a autenticação e autorização do mesmo
        /// </summary>
        /// <param name="email">Email do usuário a ser logado</param>
        /// <param name="senha">Senha do usuário a ser logado</param>
        /// <returns>Objeto contendo as informações do usuário logado para a construção do token</returns>
        UsuarioDomain Login(string email, string senha);
    }
}
