using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos e as regras de negócios da inteface IEstudioRepository
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        //String de conexão com o banco de dados contendo informações do servidor, banco de dados e login de usuário
        //Senai
        //private string StringConexao = "Data Source = NOTE16-S15; Initial Catalog = InLock_games_tarde; User Id = sa; Pwd = Senai@134";
        //Casa
        private string StringConexao = "Data Source = NOTEBOOKFAMILIA; Initial Catalog = InLock_Games; User Id = sa; Pwd = Murilo12$";

        /// <summary>
        /// Método para atualizar determinado estúdio passando as inormações pelo corpo da requisição
        /// </summary>
        /// <param name="estudioAtualizado">Objeto contendo o id do estúdio a ser atualizado e suas novas informações</param>
        public void AtualizarEstudioPeloCorpo(EstudioDomain estudioAtualizado)
        {
            //recurso para criar uma conxão com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado
                string QueryUpdate = "UPDATE Estudio SET Nome = @Nome WHERE IdEstudio = @Id;";

                //inicia a conexão com o banco de dados
                con.Open();

                //recurso para executar o comando SQL no banco de dados
                using (SqlCommand cmd = new SqlCommand(QueryUpdate,con)) 
                {
                    //substitui as variáveis no comando SQL (SqlInjection)
                    cmd.Parameters.AddWithValue("@Nome", estudioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Id", estudioAtualizado.IdEstudio);

                    //executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para atualizar as informações de um estúdio passando seu id pela Url
        /// </summary>
        /// <param name="_id">Id do estúdio a ser atualizado</param>
        /// <param name="estudioAtualizado">Objeto contendo as novas informações do estúdio</param>
        public void AtualizarEstudioPorUrl(int _id, EstudioDomain estudioAtualizado)
        {
            //recurso para criar a conexão com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado
                string QueryUpdateByUrl = "UPDATE Estudio SET Nome = @Nome WHERE IdEstudio = @Id;";

                //inicia a conexão com o banco de dados
                con.Open();

                //recurso para executar o comando SQL no banco de dados
                using (SqlCommand cmd = new SqlCommand(QueryUpdateByUrl,con))
                {
                    //substitui as variáveis no SQL (SqlInjection)
                    cmd.Parameters.AddWithValue("@Nome",estudioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@Id",_id);

                    //executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para buscar determinado estúdio por seu id
        /// </summary>
        /// <param name="_id">Id do estúdio a ser buscado</param>
        /// <returns>Objeto com as informações do estúdio buscado</returns>
        public EstudioDomain BuscarEstudioPorId(int _id)
        {
            //instancia o objeto que irá receber as informações do leitor
            EstudioDomain estudio = new EstudioDomain();

            //recurso para conectar ao banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado
                string QuerySelectById = "SELECT * FROM Estudio WHERE IdEstudio = @Id;";                

                //recurso para executar o comando no banco de dados
                using (SqlCommand cmd = new SqlCommand(QuerySelectById,con))
                {
                    //abre a conexão com o banco de dados
                    con.Open();

                    //substitui as variáveis no comando SQL (SqlInjection)
                    cmd.Parameters.AddWithValue("@Id", _id);

                    //executa o comando e armazena as informações obtidas em um leitor de dados
                    SqlDataReader leitor = cmd.ExecuteReader();

                    //verifica se o leitor recebeu alguma informação
                    if (leitor.Read())
                    {
                        //atribui as informações no leitor para o objeto
                        estudio.IdEstudio = Convert.ToInt32(leitor["IdEstudio"]);
                        estudio.Nome = Convert.ToString(leitor["Nome"]);
                        estudio.Jogos = new List<JogoDomain>();
                    }
                    //caso o leitor não possua informação nenhuma
                    else
                    {
                        return null;
                    }
                }
            }

            using (SqlConnection con2 = new SqlConnection(StringConexao))
            {
                //comando para trazer todos os jogos que pertencem ao estúdio buscado
                string QuerySelectJogo = "SELECT IdJogo,Jogo.Nome AS NomeJogo,Estudio.Nome AS NomeEstudio,Jogo.IdEstudio AS IdEstudio,Descricao,DataLancamento,Valor FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio WHERE Jogo.IdEstudio = @Id;";

                //recurso que cria uma segunda conexão com o banco de dados para o comando na tabela jogos
                using (SqlCommand cmd2 = new SqlCommand(QuerySelectJogo, con2))
                {
                    //abre a conexão com o banco de dados
                    con2.Open();

                    //substitui a variável no comando SQL (SqlInjection)
                    cmd2.Parameters.AddWithValue("@Id", _id);

                    //executa o comando e armazena em um leitor de dados
                    SqlDataReader leitor2 = cmd2.ExecuteReader();

                    //verifica se há jogos no leitor e se houver atribui à lista de jogos do estudio buscado anteriormente
                    while (leitor2.Read())
                    {
                        //instancia o objeto que cinterá as informações dos jogos armazenados no leitor2
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(leitor2["IdJogo"]),
                            IdEstudio = Convert.ToInt32(leitor2["IdEstudio"]),
                            Nome = Convert.ToString(leitor2["NomeJogo"]),
                            Descricao = Convert.ToString(leitor2["Descricao"]),
                            DataLancamento = Convert.ToString(leitor2["DataLancamento"]),
                            Valor = Convert.ToDecimal(leitor2["Valor"]),
                            Estudio = Convert.ToString(leitor2["NomeEstudio"])
                        };
                        //adiciona o jogo buscado para a lista de jogos do estúdio buscado anteriormente
                        estudio.Jogos.Add(jogo);
                    }
                }
            }

            //retorna o estúdio buscado
            return estudio;
        }

        /// <summary>
        /// Método que cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto contendo as informações do estúdio a ser cadastrado</param>
        public void CadastrarEstudio(EstudioDomain novoEstudio)
        {
            //recurso para fazer a conexão com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado
                string QueryInsert = "INSERT INTO Estudio (Nome) VALUES (@Nome);";

                //abre a conexão com o banco de dados
                con.Open();

                //recurso para executar o comando
                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    //substitui as variáveis no comando SQL (SqlInjection)
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    //executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para deletar determinado estúdio por seu id
        /// </summary>
        /// <param name="_id">Id do estúdio a ser deletado</param>
        public void DeletarEstudio(int _id)
        {
            //recurso para criar uma conexão com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado
                string QueryDelete = "DELETE FROM Estudio WHERE IdEstudio = @Id;";

                //abre(inicia) a conexão com o banco de dados
                con.Open();

                //recurso para executar o comando SQL no banco de dados
                using (SqlCommand cmd = new SqlCommand(QueryDelete,con))
                {
                    //substitui as variáveis no comando SQL (SqlInjection)
                    cmd.Parameters.AddWithValue("@Id",_id);

                    //executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para listar todos os estúdios
        /// </summary>
        /// <returns></returns>
        public List<EstudioDomain> ListarEstudios()
        {
            //instancia uma lista que armazenará todos os estúdios buscados
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            //recurso que conecta com o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado para busca de estúdios no banco de dados
                string QuerySelectEstudios = "SELECT * FROM Estudio;";

                //abre a conexão com o banco de dados
                con.Open();

                //recurso para executar o comando SQL
                using (SqlCommand cmd = new SqlCommand(QuerySelectEstudios, con))
                {
                    //executa o comando de leitura e armazena em um leitor de dados
                    SqlDataReader leitor = cmd.ExecuteReader();

                    //atribui as informações que estão dentro do leitor para a listaEstudios
                    while (leitor.Read())
                    {
                        //instancia um objeto para receber as informações
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(leitor["IdEstudio"]),
                            Nome = Convert.ToString(leitor["Nome"]),
                            Jogos = new List<JogoDomain>()
                        };

                        //adiciona o objeto com as informações à listaEstudio
                        listaEstudios.Add(estudio);
                    }
                }
            }

            using (SqlConnection con2 = new SqlConnection(StringConexao))
            {
                //comando que será executado para busca de jogos no banco de dados
                string QuerySelectJogos = "SELECT IdJogo,Jogo.Nome AS NomeJogo,Estudio.Nome AS NomeEstudio,Jogo.IdEstudio AS IdEstudio,Descricao,DataLancamento,Valor FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio;";

                //abre a conexao com o banco de dados
                con2.Open();

                //recurso que irá executar o comando 
                using (SqlCommand cmd2 = new SqlCommand(QuerySelectJogos, con2))
                {
                    //executa o comando de leitura e armazena em um leitor de dados
                    SqlDataReader leitor2 = cmd2.ExecuteReader();

                    while (leitor2.Read())
                    {
                        //percorre cada estúdio armazenado na listaEstudios anteriormente
                        foreach (EstudioDomain estudio in listaEstudios)
                        {
                            //verifica se o jogo buscado atualmente pertence ao estúdio que está sendo percorrido atualmente, caso pertença então vai atribuir este jogo buscado à lista de jogos no estúdio que está sendo percorrido.
                            if (Convert.ToInt32(leitor2["IdEstudio"]) == estudio.IdEstudio)
                            {
                                //instancia um objeto de jogo para receber as informações dos jogos do estúdio
                                JogoDomain jogo = new JogoDomain()
                                {
                                    IdJogo = Convert.ToInt32(leitor2["IdJogo"]),
                                    IdEstudio = Convert.ToInt32(leitor2["IdEstudio"]),
                                    Nome = Convert.ToString(leitor2["NomeJogo"]),
                                    Descricao = Convert.ToString(leitor2["Descricao"]),
                                    DataLancamento = Convert.ToString(leitor2["DataLancamento"]),
                                    Valor = Convert.ToDecimal(leitor2["Valor"]),
                                    Estudio = Convert.ToString(leitor2["NomeEstudio"])
                                };

                                //adiciona o jogo a lista de jogos do estúdio que está sendo percorrido atualmente
                                estudio.Jogos.Add(jogo);
                            }
                        }
                    }
                }
            }

            //retorna a lista com os estúdios buscados
            return listaEstudios;
        }
}
}