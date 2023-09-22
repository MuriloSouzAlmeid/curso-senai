using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IPresencaEventoRepository
    {
        void Deletar(Guid id);
        List<PresencaEvento> Listar();
        PresencaEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, PresencaEvento presencaEvento);
        List<PresencaEvento> ListarMinhas(Guid id);
        void Inscrever(PresencaEvento inscricao);
    }
}
