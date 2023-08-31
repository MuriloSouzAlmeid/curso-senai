using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O email de usuário é obrigatório")]
        public string? Email { get; set; }

        //O primeiro número indica o máximo
        [StringLength(20,MinimumLength = 5, ErrorMessage = "O campo senha aceita no mínimo 5 e no máximo 20 caracteres")]
        [Required(ErrorMessage = "A senha de usuário é obrigatória")]
        public string? Senha { get; set; }
        public string? Permissao { get; set; }
    }
}
