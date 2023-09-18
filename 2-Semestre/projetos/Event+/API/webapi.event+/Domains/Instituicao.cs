using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ da instituição é obrigatório")]
        [StringLength(14,ErrorMessage = "O CNPJ não pode conter mais que 14 caracteres")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O endereço da instituição é obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantisa da instituição é obrigatório")]
        public string? NomeFantasia { get; set; }
    }
}
