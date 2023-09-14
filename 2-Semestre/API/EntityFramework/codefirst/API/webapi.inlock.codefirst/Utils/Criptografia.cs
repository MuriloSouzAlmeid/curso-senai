namespace webapi.inlock.codefirst.Utils
{
    //deve ser estático pois chamaremos os métodos da classe sem a necessidade de instanciar um objeto da mesma
    public static class Criptografia
    {
        //método para criptografar a senha
        public static string GerarHash(string senha)
        {
            //retorna a senha criptografada
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// método para verificar se a hash da senha informada é a mesma da hash da senha salva no banco de dados
        /// </summary>
        /// <param name="senhaBanco">senha salva no banco de dados</param>
        /// <param name="senhaInformada">senha informada por formulário</param>
        /// <returns>True ou False</returns>
        //
        public static bool CompararHash(string senhaBanco, string senhaInformada)
        {
            //criptografa a senha informada pelo formulário e a compara com a senha que está salva no banco de dados
            return BCrypt.Net.BCrypt.Verify(senhaBanco, senhaInformada);
        }
    }
}
