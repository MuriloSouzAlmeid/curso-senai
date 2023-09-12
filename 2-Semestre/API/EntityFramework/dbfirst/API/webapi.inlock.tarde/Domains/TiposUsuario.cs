using System;
using System.Collections.Generic;

namespace webapi.inlock.tarde.Domains;

public partial class TiposUsuario
{
    //por ter usado uma primary key do tipo uniqueidentifier gera um id do tipo Guid
    public Guid IdTipoUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    //por ter usado uma foreign key do tipo uniqueidentifier gera uma lista de objetos da tabela
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
