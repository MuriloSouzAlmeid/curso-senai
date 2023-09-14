using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
{
    /// <summary>
    /// Interface que conterá os métodos para a entidade Estudio
    /// </summary>
    public interface IEstudioRepository
    {
        //método para cadastrar um estúdio
        void CadastarEstudio(Estudio novoEstudio);

        //método para listar todos os estúdios cadastrados e seus jogos
        List<Estudio> ListarEstudios();

        //método para buscar um estúdio por seu id
        Estudio BuscarEstudioPorId(Guid id);

        //método para atualizar um estúdio por seu id
        void AtualizarEstudio(Guid id, Estudio estudioAtualizado);

        //método para deletar um estúdio por seu id
        void DeletarEsudio(Guid id);
    }
}
