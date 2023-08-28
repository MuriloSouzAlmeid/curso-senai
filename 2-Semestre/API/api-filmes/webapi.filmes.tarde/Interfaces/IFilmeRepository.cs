using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface com os métodos para o repository Filme
    /// </summary>
    public interface IFilmeRepository
    {
        //CRUD

        /// <summary>
        /// Método para cadastrar um novo filme
        /// </summary>
        /// <param name="_novoFilme">Objeto com as informações dos filmes a serem cadastrados</param>
        void CadastrarFilme(FilmeDomain _novoFilme);

        /// <summary>
        /// Método para listar todos os filmes
        /// </summary>
        /// <returns>A lista com todos os filmes</returns>
        List<FilmeDomain> ListarFilmes();

        /// <summary>
        /// Método para retornar um único filme por seu id
        /// </summary>
        /// <param name="_idFilme">Id do filme a ser buscado</param>
        /// <returns>Os dados do filme com o id especificado</returns>
        FilmeDomain BurcarPorId(int _idFilme);

        /// <summary>
        /// Método para alterar um filme pelo corpo da requisição
        /// </summary>
        /// <param name="_filmeAntigo">O objeto com as novas informações do filme</param>
        void AtualizarPeloCorpo(FilmeDomain _filmeAtualizado);

        /// <summary>
        /// Método para alterar um filme pelo id passado pela url
        /// </summary>
        /// <param name="_idFilme">Id do filme a ser alterado</param>
        /// <param name="_filmeAntigo">O objeto com as novas informações do filme</param>
        void AtualizarPelaUrl(int _idFilme, FilmeDomain _filmeAtualizado);

        /// <summary>
        /// Método para deltar um filme do banco de dados
        /// </summary>
        /// <param name="_idFilme">Id do filme a ser deletado</param>
        void DeletarFilme(int _idFilme);
    }
}
