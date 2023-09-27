using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        void Deletar(Guid id);

        void Atualizar(Guid id, Usuario usuarioAtualizado);

        Usuario Login(string email, string senha);

        Usuario BuscarPorId(Guid id);
    }
}
