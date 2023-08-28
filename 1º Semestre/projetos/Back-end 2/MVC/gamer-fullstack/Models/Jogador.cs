using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamer_fullstack.Models
{
    public class Jogador
    {
        [Key]
        public int IdJogador {get;set;}
        public string? NomeJogador {get;set;}
        public string? Email {get;set;}
        public string? Senha {get;set;}

        //Conexão com a Classe Equipe - Entity Framework
        public Equipe Equipe {get;set;}
        
        //Pede como parâmetro a classe da qual faz parte a chave extrangeira
        [ForeignKey("Equipe")]
        public int IdEquipe {get;set;} 
    }
}
