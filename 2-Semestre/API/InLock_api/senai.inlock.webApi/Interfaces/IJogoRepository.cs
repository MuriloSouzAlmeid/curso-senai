using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface que contém os métodos e regras de negócios referente ao CRUD da tabela Estúdio
    /// </summary>
    public interface IJogoRepository
    {
        /// <summary>
        /// Método para cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto contando as informações do jogo a ser cadastrado</param>
        void CadastrarJogo(JogoDomain novoJogo);

        /// <summary>
        /// Método para listar todos os jogos cadastrados
        /// </summary>
        /// <returns>Lista com todos os jogos cadastrados</returns>
        List<JogoDomain> ListarJogos();

        /// <summary>
        /// Método para buscar determinado jogo por seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser buscado</param>
        /// <returns>Objeto contendo as informações do jogo buscado</returns>
        JogoDomain BuscarJogoPorId(int id);

        /// <summary>
        /// Método para atualizar um jogo passando seu id e suas novas informações pelo corpo da requisição
        /// </summary>
        /// <param name="jogoAtualizado">Objeto contendo o id e as novas informações do jogo a ser atualizado</param>
        void AtualizarJogoPorCorpo(JogoDomain jogoAtualizado);

        /// <summary>
        /// Método para atualizar um jogo passando seu id pela url
        /// </summary>
        /// <param name="id">Id do objeto a ser aualizado</param>
        /// <param name="jogoAtualizado">Objeto contendo as novas informações do jogo a ser atualizado</param>
        void AtualizarJogoPelaUrl(int id, JogoDomain jogoAtualizado);

        /// <summary>
        /// Método para deletar determinado jogo por seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser deletado</param>
        void DeletarJogo(int id);
    }
}
