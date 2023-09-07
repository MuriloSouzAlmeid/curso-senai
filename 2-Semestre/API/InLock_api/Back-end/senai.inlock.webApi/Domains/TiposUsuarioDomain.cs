namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela TiposUsuario do banco de dados
    /// </summary>
    public class TiposUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        public string? Titulo { get; set; }
    }
}
