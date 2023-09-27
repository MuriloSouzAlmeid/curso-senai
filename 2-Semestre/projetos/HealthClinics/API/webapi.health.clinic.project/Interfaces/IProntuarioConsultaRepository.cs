using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IProntuarioConsultaRepository
    {
        void Cadastrar(ProntuarioConsulta novoProntuario);

        void Atualizar(Guid id, ProntuarioConsulta prontuarioAtualizado);

        ProntuarioConsulta BuscarPorId(Guid id);
    }
}
