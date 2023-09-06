using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos e as regras de negócios da inteface IEstudioRepository
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// Método para atualizar determinado estúdio passando as inormações pelo corpo da requisição
        /// </summary>
        /// <param name="estudioAtualizado">Objeto contendo o id do estúdio a ser atualizado e suas novas informações</param>
        public void AtualizarEstudioPeloCorpo(EstudioDomain estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para atualizar as informações de um estúdio passando seu id pela Url
        /// </summary>
        /// <param name="_id">Id do estúdio a ser atualizado</param>
        /// <param name="estudioAtualizado">Objeto contendo as novas informações do estúdio</param>
        public void AtualizarEstudioPorUrl(int _id, EstudioDomain estudioAtualizado)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para buscar determinado estúdio por seu id
        /// </summary>
        /// <param name="_id">Id do estúdio a ser buscado</param>
        /// <returns>Objeto com as informações do estúdio buscado</returns>
        public EstudioDomain BuscarEstudioPorId(int _id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto contendo as informações do estúdio a ser cadastrado</param>
        public void CadastrarEstudio(EstudioDomain novoEstudio)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para deletar determinado estúdio por seu id
        /// </summary>
        /// <param name="_id">Id do estúdio a ser deletado</param>
        public void DeletarEstudio(int _id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método para
        /// </summary>
        /// <returns></returns>
        public List<EstudioDomain> ListarEstudios()
        {
            throw new NotImplementedException();
        }
    }
}
