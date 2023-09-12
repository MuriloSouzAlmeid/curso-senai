using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interfaces
{
    /// <summary>
    /// Interface que define os métodos obrigatórios para o respositório EstudioRepository
    /// </summary>
    public interface IEstudioRepository
    {
        List<Estudio> Listar();

        Estudio BuscarPorId(Guid id);

        void Cadatrar(Estudio novoEstudio);

        void Atualizar(Guid id, Estudio estudioAtualizado);

        void Deletar(Guid id);

        List<Estudio> ListarComJogos();
    }
}
