using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        //Utilizada para conectar ao banco de dados
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: nome do servidor do banco
        /// Initial catalog: Nome do BD
        /// Autenticação:
        /// -Windows: Integrated Security = True
        /// SqlServer: User Id = sa; Pwd = Senha
        /// </summary>

        // Senai
            private string StringConexao = "Data Source = NOTE16-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        //Casa:
        //private string StringConexao = "Data Source = NOTEBOOKFAMILIA; Initial Catalog = Filmes; User Id = sa; Pwd = Murilo12$";

        /// <summary>
        /// Método para atualizar as informações de um gênero passando o id pela Url
        /// </summary>
        /// <param name="_idGenero">O id do gênero a ser atualizado</param>
        /// <param name="_genero">O objeto com as novas informações do gênero</param>
        public void AtualizarIdUrl(int _idGenero, GeneroDomain _genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdateByUrl = "UPDATE Genero SET Genero.Nome = @Nome WHERE Genero.IdGenero = @Id";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(QueryUpdateByUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Id", _idGenero);
                    cmd.Parameters.AddWithValue("@Nome", _genero.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método para atualizar um gênero existente pelo id no corpo
        /// </summary>
        /// <param name="_genero">O objeto contendo as informações do gênero que serão atualizadas</param>
        public void AtualizarPorIdGenero(GeneroDomain _genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryUpdate = "UPDATE Genero SET Genero.Nome = @Nome WHERE Genero.IdGenero = @Id";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", _genero.Nome);
                    cmd.Parameters.AddWithValue("@Id", _genero.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int id)
        {
            GeneroDomain genero = new GeneroDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelectById = "SELECT * FROM Genero WHERE Genero.IdGenero = @Id";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    sdr = cmd.ExecuteReader();
                }

                if (sdr.Read())
                {
                    genero.IdGenero = Convert.ToInt32(sdr[0]);
                    genero.Nome = Convert.ToString(sdr[1]);

                    return genero;
                }      
            }
            return null;
        }

        /// <summary>
        /// Esse método vai cadastrar um novo gênero
        /// </summary>
        /// <param name="NovoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain NovoGenero)
        {
            //Declara o SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada           
                string QueryInsert = $"INSERT INTO Genero (Nome) VALUES (@Nome)";

                //declara o SqlCommand passando a query que será executada e a conexão com o banco de dados
                using (SqlCommand command = new SqlCommand(QueryInsert, con))
                {
                    //Fazendo o SQL injection antes de executar
                    //Vai converter o que estiver marcado como o primeiro parâmetro pelo o que estiver no segundo parâmetro
                    command.Parameters.AddWithValue("@Nome", NovoGenero.Nome);

                    //abre a conexão com o banco de dados
                    con.Open();

                    //apenas executar o que está na variável como uma query
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar determinado objeto a partir do Id
        /// </summary>
        /// <param name="_idGenero">Id do objeto a ser deletado</param>
        public void Deletar(int _idGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE Genero WHERE Genero.IdGenero = @IdGenero";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", _idGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os objetos do tipo genero
        /// </summary>
        /// <returns>Lista de objetos do tipo gênero</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de generos onde serão armazenados os generos
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();


            //Declara a SqlConnection, passando a string de conexão como parâmetro. É o objeto que faz a conexão com o BD
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada, no caso, é o select
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";


                //Abre a conexão com o BD
                con.Open();

                //Declara o SqlDataReader para percorrer/ler a tabela no BD
                SqlDataReader rdr;


                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armazena os dados na rdr
                    rdr = cmd.ExecuteReader();


                    //Enquanto houver registros a serem lidos no rdr, o laço se repetirá
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero ao valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade nome ao valor da coluna nome
                            Nome = Convert.ToString(rdr[1])

                            //ou: NomeGenero = rdr["Nome"].ToString()

                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaGeneros.Add(genero);


                    }
                }
            }

            //Retorna a lista de generos
            return ListaGeneros;
        }


    }
}