namespace webapi.event_.Utils
{
    public static class Criptografia
    {
        public static string GerarHash(string senha)
        {
            //criptografa a senha
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(string senhaInformada, string senhaCadastrada)
        {
            //retorna se a senha é igual(true) ou não(false)
            return BCrypt.Net.BCrypt.Verify(senhaInformada, senhaCadastrada);
        }
    }
}
