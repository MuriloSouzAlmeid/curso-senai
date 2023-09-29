using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.health.clinic.project.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    [Index(nameof(RazaoSocial), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia da clínica é obrigatório")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "A razão social fantasia da clínica é obrigatório")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ fantasia da clínica é obrigatório")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(300)")]
        [Required(ErrorMessage = "O endereço fantasia da clínica é obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de abertura fantasia da clínica é obrigatório")]
        //TimeInly define que o tipo de dado será horário (apenas horário)
        public TimeOnly HorarioAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de encerramento da clínica é obrigatório")]
        public TimeOnly HorarioEncerramento { get; set; }
    }
}
