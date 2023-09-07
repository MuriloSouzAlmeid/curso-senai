using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface que contém os métodos e regras de negócios referente ao CRUD da tabela Estúdio
    /// </summary>
    public interface IEstudioRepository
    {
        /// <summary>
        /// Método que cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto contendo as informações do estúdio a ser cadastrado</param>
        void CadastrarEstudio(EstudioDomain novoEstudio);

        /// <summary>
        /// Método que lista todos os estúdios cadastrados
        /// </summary>
        /// <returns>Lista com todos os estúdios</returns>
        List<EstudioDomain> ListarEstudios();

        /// <summary>
        /// Método para buscar determinado estúdio por seu id
        /// </summary>
        /// <param name="_id">Id do estúdio a ser buscado</param>
        /// <returns>Objeto com as informações do estúdio buscado</returns>
        EstudioDomain BuscarEstudioPorId(int _id);

        /// <summary>
        /// Método para atualizar determinado estúdio passando as inormações pelo corpo da requisição
        /// </summary>
        /// <param name="estudioAtualizado">Objeto contendo o id do estúdio a ser atualizado e suas novas informações</param>
        void AtualizarEstudioPeloCorpo(EstudioDomain estudioAtualizado);

        /// <summary>
        /// Método para atualizar as informações de um estúdio passando seu id pela Url
        /// </summary>
        /// <param name="_id">Id do estúdio a ser atualizado</param>
        /// <param name="estudioAtualizado">Objeto contendo as novas informações do estúdio</param>
        void AtualizarEstudioPorUrl(int _id, EstudioDomain estudioAtualizado);

        /// <summary>
        /// Método para deletar determinado estúdio por seu id
        /// </summary>
        /// <param name="_id">Id do estúdio a ser deletado</param>
        void DeletarEstudio(int _id);
    }
}
