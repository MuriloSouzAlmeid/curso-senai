using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos de Usuario
    /// </summary>
    public interface IUsuarioRepository
    {
        // LOGIN
        UsuarioDomain LoginUsuario(string email, string senha);
    }
}
