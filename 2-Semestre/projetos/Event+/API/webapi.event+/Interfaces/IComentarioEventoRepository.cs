using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IComentarioEventoRepository
    {
        void Cadastrar(ComentarioEvento comentarioEvento);
        void Deletar(Guid id);
        List<ComentarioEvento> Listar();
        ComentarioEvento BuscarPorId(Guid id);
    }
}
