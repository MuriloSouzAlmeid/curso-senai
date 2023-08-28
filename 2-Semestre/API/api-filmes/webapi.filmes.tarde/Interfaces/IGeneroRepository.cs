using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responável pelo GeneronRepository
    /// Definr os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD

        //TipoDeRetorno NomeDoMétodo(tipoDoParâmetro nomeDoParâmetro);

        /// <summary>
        /// Método responsável por cadastrar novo gênero
        /// </summary>
        /// <param name="_novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain _novoGenero);

        /// <summary>
        /// Método responável por retornar todos os gêneros cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Método responsável por buscar um objeto através de seu Id
        /// </summary>
        /// <param name="_idGenero">Id do objeto que será buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int _idGenero);

        /// <summary>
        /// Método responsável por atualizar um gênero existente pelo corpo da requisição
        /// </summary>
        /// <param name="_genero">Objeto com novas informações</param>
        void AtualizarPorIdGenero(GeneroDomain _genero);

        /// <summary>
        /// Método responsável por atualizar um gênero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="_id">Id do objeto a ser alterado</param>
        /// <param name="_genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int _idGenero, GeneroDomain _genero);

        /// <summary>
        /// Método responsável por deletar um gênero existente
        /// </summary>
        /// <param name="_id">Id do ojeto a ser deletado</param>
        void Deletar(int _idGenero);
    }
}
