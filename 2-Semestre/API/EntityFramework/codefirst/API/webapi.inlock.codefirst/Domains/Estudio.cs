using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
{
    //define que esta classe será uma tabela na hora de construir o banco de dados pela Context
    //dentro do parênteses definimos qual será o nome da tabela
    [Table("Estudio")]
    public class Estudio
    {
        //define que o atributo a seguir será a chave primária da tabela
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        //define que o atributo a seguir será uma coluna sem ser a chave primária
        //Dentro do parenteses temos o nome do tipo de dado do atributo
        [Column(TypeName = "VARCHAR(100)")]
        //define que o campo é obrigatório e passa também uma mensagem de erro caso não seja atribuído
        [Required(ErrorMessage = "Nome obrigatório.")]
        public string Nome { get; set; }

        //referência à lista de jogos que o estúdio contém
        public List<Jogo> Jogo { get; set; }
    }
}
