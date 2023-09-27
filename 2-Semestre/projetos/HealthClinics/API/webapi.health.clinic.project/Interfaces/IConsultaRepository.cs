using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta novaConsulta);

        void Deletar(Guid id);

        void Atualizar(Guid id, Consulta consultaAtualizada);

        Consulta BuscarPorId(Guid id);

        Consulta BuscarMinhas(Guid id);

        List<Consulta> ListarTodas();
    }
}
