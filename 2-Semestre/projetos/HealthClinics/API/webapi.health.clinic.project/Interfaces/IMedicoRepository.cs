using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico novoMedico);

        void Atualizar(Guid id, Medico medicoAtualizado);

        Medico BuscarPorId(Guid id);

        List<Medico> Listar();
    }
}
