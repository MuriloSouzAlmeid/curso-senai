using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente novoPaciente);

        void Atualizar(Guid id, Paciente PacienteAtualizado);

        Paciente BuscarPorId(Guid id);

        List<Paciente> Listar();
    }
}
