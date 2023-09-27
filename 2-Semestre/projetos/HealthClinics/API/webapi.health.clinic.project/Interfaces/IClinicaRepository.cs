using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);

        void Deletar(Guid id);

        void Atualizar(Guid id, Clinica clinicaAtualizada);

        Clinica BuscarPorId(Guid id);

        List<Clinica> Listar();
    }
}
