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
                string QuerySelectJogos = "SELECT * FROM Jogo;";

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
                                    Nome = Convert.ToString(leitor2["Nome"]),
                                    Descricao = Convert.ToString(leitor2["Descricao"]),
                                    DataLancamento = Convert.ToString(leitor2["DataLancamento"]),
                                    Valor = Convert.ToDecimal(leitor2["Valor"])
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