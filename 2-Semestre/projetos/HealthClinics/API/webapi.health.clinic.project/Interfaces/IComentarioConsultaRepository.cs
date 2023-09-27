using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface IComentarioConsultaRepository
    {
        void Cadastrar(ComentarioConsulta novoComentario);

        void Deletar(Guid id);

        ComentarioConsulta BuscarPorId(Guid id);
    }
}
