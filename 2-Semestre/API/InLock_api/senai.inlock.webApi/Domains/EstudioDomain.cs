using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela Estudios do banco de dados
    /// </summary>
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        public string? Nome { get; set; }
    }
}
