using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);

        void Deletar(Guid id);

        void Atualizar(Guid id, Usuario usuarioAtualizado);
    }
}
