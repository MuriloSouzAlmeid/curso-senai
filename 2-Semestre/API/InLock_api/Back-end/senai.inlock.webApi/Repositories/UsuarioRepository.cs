using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// Repositório que implementa os métodos e as regras de negócios da inteface IUsuarioRepository
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        //String de conexão
        //Senai
        //private string StringConexao = "Data Source = NOTE16-S15; Initial Catalog = InLock_games_tarde; User Id = sa; Pwd = Senai@134";
        //Casa
        private string StringConexao = "Data Source = NOTEBOOKFAMILIA; Initial Catalog = InLock_Games; User Id = sa; Pwd = Murilo12$";

        /// <summary>
        /// Método para verificar se um usuário está cadastrado no banco de dados
        /// </summary>
        /// <param name="email">Email do usuário a ser verificado</param>
        /// <param name="senha">Senha do Usuário a ser verificada</param>
        /// <returns>Objeto contendo as informações do usuário se o mesmo estiver cadastrado, se não estiver retorna um objeto nulo</returns>
        public UsuarioDomain Login(string email, string senha)
        {
            //recurso que conecta o banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando que será executado
                string QueryLogin = "SELECT IdUsuario,Usuario.IdTipoUsuario AS TipoUsuario,Email,Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha;";

                //abre a conexão com o baco de dados
                con.Open();

                //recurso que irá executar o comando
                using (SqlCommand cmd = new SqlCommand(QueryLogin,con))
                {
                    //define o valor das variáveis (SqlInjection)
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    //atribui os valores obtidos da consulta para um leitor
                    SqlDataReader leitor = cmd.ExecuteReader();

                    //atribui as informações dentro do leitor para um novo objeto
                    if (leitor.Read())
                    {
                        //instancia o objeto que receberá as informções do usuário
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(leitor["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(leitor["TipoUsuario"]),
                            Email = Convert.ToString(leitor["Email"]),
                            TipoUsuario = new TiposUsuarioDomain()
                            {
                                IdTipoUsuario = Convert.ToInt32(leitor["TipoUsuario"]),
                                Titulo = Convert.ToString(leitor["Titulo"])
                            }
                        };

                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
