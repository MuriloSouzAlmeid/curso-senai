using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos e as regras de negócios da inteface IUsuarioRepository
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioDomain Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
