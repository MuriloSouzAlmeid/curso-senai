using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento novoEvento);

        List<Evento> Listar();

        Evento BuscarPorId(Guid id);

        void Deletar(Guid id);

        void Atualizar(Guid id, Evento eventoAtualizado);
    }
}
