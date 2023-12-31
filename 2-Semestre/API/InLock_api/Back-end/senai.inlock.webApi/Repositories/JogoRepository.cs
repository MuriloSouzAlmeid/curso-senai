﻿using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos e as regras de negócios da inteface IJogoRepository
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        //String de conexão com o banco de dados contendo informações do servidor, banco de dados e login de usuário
        //Senai
        private string StringConexao = "Data Source = NOTE16-S15; Initial Catalog = InLock_games_tarde; User Id = sa; Pwd = Senai@134";
        //Casa
        //private string StringConexao = "Data Source = NOTEBOOKFAMILIA; Initial Catalog = InLock_Games; User Id = sa; Pwd = Murilo12$";

        /// <summary>
        /// Método para atualizar um jogo passando seu id pela url
        /// </summary>
        /// <param name="id">Id do objeto a ser aualizado</param>
        /// <param name="jogoAtualizado">Objeto contendo as novas informações do jogo a ser atualizado</param>
        public void AtualizarJogoPelaUrl(int id, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdateByUrl = "UPDATE Jogo SET IdEstudio = @IdEstudio,Nome = @Nome,Descricao = @Descricao,DataLancamento = @DataLancamento,Valor = @Valor WHERE IdJogo = @IdJogo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdateByUrl,con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);
                    cmd.Parameters.AddWithValue("@IdEstudio", jogoAtualizado.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogoAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogoAtualizado.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para atualizar um jogo passando seu id e suas novas informações pelo corpo da requisição
        /// </summary>
        /// <param name="jogoAtualizado">Objeto contendo o id e as novas informações do jogo a ser atualizado</param>
        public void AtualizarJogoPorCorpo(JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdateByBody = "UPDATE Jogo SET IdEstudio = @IdEstudio,Nome = @Nome,Descricao = @Descricao,DataLancamento = @DataLancamento,Valor = @Valor WHERE IdJogo = @IdJogo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdateByBody, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo",jogoAtualizado.IdJogo);
                    cmd.Parameters.AddWithValue("@IdEstudio",jogoAtualizado.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome",jogoAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Descricao",jogoAtualizado.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento",jogoAtualizado.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor",jogoAtualizado.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para buscar determinado jogo por seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser buscado</param>
        /// <returns>Objeto contendo as informações do jogo buscado</returns>
        public JogoDomain BuscarJogoPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelectById = "SELECT IdJogo,Jogo.IdEstudio AS IdEstudio,Jogo.Nome AS NomeJogo,Estudio.Nome AS NomeEstudio,Descricao,DataLancamento,Valor FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio WHERE IdJogo = @IdJogo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelectById,con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo",id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = Convert.ToString(rdr["NomeJogo"]),
                            Descricao = Convert.ToString(rdr["Descricao"]),
                            DataLancamento = Convert.ToString(rdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(rdr["Valor"]),
                            Estudio = Convert.ToString(rdr["NomeEstudio"])
                        };

                        return jogo;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Método para cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto contando as informações do jogo a ser cadastrado</param>
        public void CadastrarJogo(JogoDomain novoJogo)
        {
            //recurso para conectar o repositório com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado dentro do banco de dados
                string QueryInsert = "INSERT INTO Jogo (IdEstudio,Nome,Descricao,DataLancamento,Valor) VALUES (@IdEstudio,@Nome,@Descricao,@DataLancamento,@Valor);";

                //abre a conexão com o banco
                con.Open();

                //recurso que irá executar o comando SQL
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    //configura a troca de valores pelas variáveis no comando (SqlInject)
                    cmd.Parameters.AddWithValue("@IdEstudio",novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome",novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento",novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor",novoJogo.Valor);

                    //executa o comando de Insert no banco de dados
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para deletar determinado jogo por seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser deletado</param>
        public void DeletarJogo(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM Jogo WHERE IdJogo = @Id;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@Id",id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para listar todos os jogos cadastrados
        /// </summary>
        /// <returns>Lista com todos os jogos cadastrados</returns>
        public List<JogoDomain> ListarJogos()
        {
            //instancia a lista de jogos que será retornada no final
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            //recurso de conexão com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado
                string QuerySelectAll = "SELECT IdJogo,Jogo.IdEstudio AS IdEstudio,Jogo.Nome AS NomeJogo,Descricao,DataLancamento,Valor,Estudio.Nome AS NomeEstudio FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                //abre a conexão com o banco de dados
                con.Open();

                //recurso que executa o comando
                using (SqlCommand cmd = new SqlCommand(QuerySelectAll, con))
                {
                    //executa o comando de leitura e atribui seu resultado para um leitor de dados
                    SqlDataReader leitor = cmd.ExecuteReader();

                    //atribui os valores armazenados no leitor para a lista de jogos
                    while (leitor.Read())
                    {
                        //cria um objeto que receberá as informações do leitor
                        JogoDomain jogo = new JogoDomain() {
                            IdJogo = Convert.ToInt32(leitor["IdJogo"]),
                            IdEstudio = Convert.ToInt32(leitor["IdEstudio"]),
                            Nome = Convert.ToString(leitor["NomeJogo"]),
                            Descricao = Convert.ToString(leitor["Descricao"]),
                            DataLancamento = Convert.ToString(leitor["DataLancamento"]),
                            Valor = Convert.ToDecimal(leitor["Valor"]),
                            Estudio = Convert.ToString(leitor["NomeEstudio"])
                        };

                        //salva esse objeto na lista antes de reiniciar o laço
                        listaJogos.Add(jogo);
                    }
                }
            }

            //retorna a lista com os jogos dentro
            return listaJogos;
        }
    }
}
