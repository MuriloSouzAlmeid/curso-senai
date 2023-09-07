using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela Jogo do banco de dados
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O Estúdio do jogo é obrigatório")]
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição do jogo é obrigatória")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória")]
        public string? DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo é obrigatório")]
        public decimal Valor { get; set; }


        //Referência à classe EstudioDomain
        public EstudioDomain? Estudio { get; set; }
    }
}
