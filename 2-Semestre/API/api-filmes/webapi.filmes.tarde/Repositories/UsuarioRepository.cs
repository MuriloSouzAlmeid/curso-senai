using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // Senai
        private string StringConexao = "Data Source = NOTE16-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        //Casa:
        //private string StringConexao = "Data Source = NOTEBOOKFAMILIA; Initial Catalog = Filmes; User Id = sa; Pwd = Murilo12$";


        public UsuarioDomain LoginUsuario(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelectLogin = "SELECT IdUsuario,Nome,Email,Permissao FROM Usuario WHERE Usuario.Email = @Email AND Usuario.Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelectLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader leitor = cmd.ExecuteReader();

                    if (leitor.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(leitor["IdUsuario"]),
                            Nome = Convert.ToString(leitor["Nome"]),
                            Email = Convert.ToString(leitor["Email"]),
                        };

                        usuario.Permissao = Convert.ToInt32(leitor["Permissao"]) == 1 ? "Administrador" : "Usúario Comun";

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
