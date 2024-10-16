using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema.Contexts;
using sistema.Models;

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
            var turma = _context.Turmas.FirstOrDefault(turma => turma.TurmaId == turmaId);

            var atividades = _context.Atividades.Include(atividade => atividade.Turma).Where(atividade => atividade.TurmaId == turmaId).ToList();

            var professor = _context.Professores.FirstOrDefault(professor => professor.ProfessorId == HttpContext.Session.GetInt32("ProfessorId"));

            ViewBag.TurmaId = turmaId;
            ViewBag.NomeProfessor = professor!.Nome;

            ViewBag.NomeTurma = turma!.Nome;

            return View(atividades);
        }

        [HttpPost]
        public IActionResult CadastrarAtividade(string descricaoAtividade, int turmaId)
        {
            Atividade novaAtividade = new Atividade() 
            {
                Descricao = descricaoAtividade,
                TurmaId = turmaId
            };

            _context.Atividades.Add(novaAtividade);

            _context.SaveChanges();

            return RedirectToAction("Index", new {turmaId});
        }
    }
}
