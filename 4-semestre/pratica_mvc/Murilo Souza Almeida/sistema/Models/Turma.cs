using System;
using System.Collections.Generic;

namespace sistema.Models;

public partial class Turma
{
    public int TurmaId { get; set; }

    public int? ProfessorId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Atividade> Atividades { get; set; } = new List<Atividade>();

    public virtual Professor? Professor { get; set; }
}
