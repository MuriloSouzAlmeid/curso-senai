using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using gamer_fullstack.infra;
using gamer_fullstack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gamer_fullstack.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        Context bancoDeDados = new Context();
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        //Cria uma propriedade paraexibir mensagens de erro ao usuário
        [TempData]
        public string Message {get;set;}

        [Route("Login")]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            string email = form["Email"]!.ToString();

            string senha = form["Senha"]!.ToString();

            Jogador jogadorBuscado = bancoDeDados.Jogador.FirstOrDefault(x => x.Email == email && x.Senha == senha)!;

            //Lógica de Seção

            //Posso comparar objetos com null
            if(jogadorBuscado != null){

                //Cria uma seção no arquivo
                HttpContext.Session.SetString("UserName", jogadorBuscado.NomeJogador!);
                //Volta para a raiz
                return LocalRedirect("~/");
            }else{
                this.Message = "Erro ao logar o usuário. Tente novamente!";
                return LocalRedirect("~/Login/Login");
            }
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("UserName");
            return LocalRedirect("~/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}