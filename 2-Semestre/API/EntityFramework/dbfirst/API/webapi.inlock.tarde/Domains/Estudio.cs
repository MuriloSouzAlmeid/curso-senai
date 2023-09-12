using System;
using System.Collections.Generic;

namespace webapi.inlock.tarde.Domains;

public partial class Estudio
{
    //por ter usado uma primary key do tipo uniqueidentifier gera um id do tipo Guid
    public Guid IdEstudio { get; set; }

    public string Nome { get; set; } = null!;

    //por ter usado uma foreign key do tipo uniqueidentifier gera uma lista de objetos da tabela
    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
