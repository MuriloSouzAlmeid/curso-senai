using Microsoft.AspNetCore.Mvc;
using sistema.Contexts;

namespace sistema.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly sistemaContext _context;

        public AtividadeController(sistemaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int turmaId)
        {
            var atividades = _context.Atividades.Where(atividade => atividade.TurmaId == turmaId).ToList();

            var turma = _context.Turmas.FirstOrDefault(turma => turma.TurmaId == turmaId);

            ViewBag.NomeTurma = turma!.Nome;

            return View(atividades);
        }
    }
}
