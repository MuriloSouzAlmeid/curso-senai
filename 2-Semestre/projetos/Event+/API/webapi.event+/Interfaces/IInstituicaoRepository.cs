using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao novaInstituica);

        List<Instituicao> ListarInstituicoes();

        Instituicao BuscarInstituicao(Guid id);

        void DeletarInstituicao(Guid id);

        void AtualizarInstituicao(Guid id, Instituicao instituicaoAtualizada);
    }
}
