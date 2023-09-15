using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.codefirst.ViewModels
{
    //Classe que contem apenas as propriedades da classe usuário necessárias para realizar a operação de login
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo de email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve ter no mínimo 5 e no máximo 60 caracteres")]
        public string Senha { get; set; }
    }
}
