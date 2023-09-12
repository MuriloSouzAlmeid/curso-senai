using System;
using System.Collections.Generic;

namespace webapi.inlock.tarde.Domains;

public partial class Jogo
{
    //por ter usado uma primary key do tipo uniqueidentifier gera um id do tipo Guid
    public Guid IdJogo { get; set; }

    //por ter usado uma foreign key do tipo uniqueidentifier gera um id do tipo Guid
    public Guid? IdEstudio { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime DataLancamento { get; set; }

    public decimal Valor { get; set; }

    //por ter uma ponte com o estudio por meio de uma foreign key cria um objeto virtual do tipo estúdio
    public virtual Estudio? IdEstudioNavigation { get; set; }
}
