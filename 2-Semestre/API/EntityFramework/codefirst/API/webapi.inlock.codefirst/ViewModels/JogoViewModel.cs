using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.codefirst.ViewModels
{
    public class JogoViewModel
    {
        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição do jogo é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O preço do jogo é pbrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O id do estúdio do jogo é obrigatório")]
        public Guid IdEstudio { get; set; }
    }
}
