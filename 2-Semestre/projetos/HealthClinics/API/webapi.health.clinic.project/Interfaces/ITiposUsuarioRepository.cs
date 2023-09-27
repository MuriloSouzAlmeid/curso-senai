using webapi.health.clinic.project.Domains;

namespace webapi.health.clinic.project.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario novoTipo);

        void Deletar(Guid id);

        TiposUsuario BuscarPorId(Guid id);
    }
}
