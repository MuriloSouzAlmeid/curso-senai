using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação da presença é obrigatória")]
        public bool Situacao { get; set; }


        //Referência à tabela Usuario
        [Required(ErrorMessage = "O id so usuário é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //Referência à tabela Evento
        [Required(ErrorMessage = "O id do evento é obrigatório")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
