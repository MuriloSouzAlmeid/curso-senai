using System;
using System.Collections.Generic;

namespace sistema.Models;

public partial class Professor
{
    public int ProfessorId { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<Turma> Turmas { get; set; } = new List<Turma>();
}
