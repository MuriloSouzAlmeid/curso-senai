using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(Guid id, Especialidade especialidadeAtualizada);

        Especialidade BuscarPorId(Guid id);

        List<Especialidade> Listar();
    }
}
