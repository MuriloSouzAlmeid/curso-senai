using System.ComponentModel.DataAnnotations;

namespace gamer_fullstack.Models
{
    public class Equipe
    {
        // Data Annotation (Anotações de dados na aplicação) - Válida apenas para a primeira propriedade abaixo dela

        //Indentifica a propriedade como uma primary key (chave primária)
        [Key]
        public int IdEquipe {get;set;}

        public string? NomeEquipe {get;set;}
        public string? ImagemEquipe {get;set;}

        //Criação de uma collection (coleção) de objetos da classe Jogador
        public ICollection<Jogador>? Jogador {get;set;}
    }
}