using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IComentariosEventoRepository
    {
        void Cadastrar(ComentariosEvento comentarioEvento);
        void Deletar(Guid id);
        List<ComentariosEvento> Listar();
        ComentariosEvento BuscarPorId(Guid id);
        ComentariosEvento BuscarPorIdUsuarioEvento(Guid idUsuario, Guid idEvento);
        List<ComentariosEvento> ListarPorUsuarioEvento(Guid idUsuario, Guid idEvento);
        List<ComentariosEvento> ListarSometeExibe(Guid idEvento);

        List<ComentariosEvento> ListarPorIdEvento(Guid idEvento);
    }
}
