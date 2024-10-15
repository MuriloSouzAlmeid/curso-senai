using Microsoft.AspNetCore.Mvc;
using sistema.Contexts;
using sistema.Models;

namespace sistema.Controllers
{
    public class LoginController : Controller
    {
        private readonly sistemaContext _context;

        public LoginController(sistemaContext context) { 
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logar(string email, string senha)
        {
            try
            {
                Professor professor = _context.Professores.FirstOrDefault(professor => professor.Email == email && professor.Senha == senha)!;

                if(professor != null)
                {
                    // pega da propriedade do banco de dados (não precisa  que possua tal id e seta o valor na HttpContext.Session
                    HttpContext.Session.SetInt32("ProfessorId", professor.ProfessorId);
                    HttpContext.Session.SetString("Nome", professor.Nome);

                    // funciona como o routes e redireciona para a ação Index, sendo o próprio método Index que retornaa a View()
                    // e posso passar como um segundo parâmetro qual o controller que eu quero executar a ação.
                    return RedirectToAction("Index", "Professor");
                }

                // Define qual a mensagem de erro que será mostrada
                TempData["Mensagem"] = "Email ou senha incorretos";
                return RedirectToAction("Index", "Login");
                
            }catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
