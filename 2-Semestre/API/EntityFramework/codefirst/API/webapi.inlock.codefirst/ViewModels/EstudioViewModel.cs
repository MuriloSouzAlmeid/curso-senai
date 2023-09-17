using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.codefirst.ViewModels
{
    public class EstudioViewModel
    {
        [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
        public string NomeEstudio { get; set; }
    }
}
