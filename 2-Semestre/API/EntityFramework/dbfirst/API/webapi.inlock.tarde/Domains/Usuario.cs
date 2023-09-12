using System;
using System.Collections.Generic;

namespace webapi.inlock.tarde.Domains;

public partial class Usuario
{
    //por ter usado uma primary key do tipo uniqueidentifier gera um id do tipo Guid
    public Guid IdUsuario { get; set; }

    //por ter usado uma foreign key do tipo uniqueidentifier gera um id do tipo Guid
    public Guid? IdTipoUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    //por ter uma ponte com o TiposUsuario por meio de uma foreign key cria um objeto virtual do tipo Tiposusuario
    public virtual TiposUsuario? IdTipoUsuarioNavigation { get; set; }
}
