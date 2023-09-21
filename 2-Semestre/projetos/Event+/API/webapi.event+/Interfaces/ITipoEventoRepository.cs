using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoEvento);
        List<TipoEvento> Listar();
        TipoEvento BuscarPorId(Guid id);
        void Deletar(Guid id);
        void Atualizar(Guid id, TipoEvento tipoEvento);
    }
}
