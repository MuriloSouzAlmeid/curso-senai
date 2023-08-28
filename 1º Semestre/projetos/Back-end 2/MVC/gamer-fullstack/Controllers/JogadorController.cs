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
    public class JogadorController : Controller
    {
        Context bancoDeDados = new Context();
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        [Route("ListaDeJogadores")]
        public IActionResult Index()
        {
            //Tras os dados do usuario
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            //To list lista o que está dentro da tabela específicada
            ViewBag.Jogador = bancoDeDados.Jogador.ToList();
            ViewBag.Equipe = bancoDeDados.Equipe.ToList();

            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Jogador novoJogador = new Jogador();

            novoJogador.NomeJogador = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha = form["Senha"];
            novoJogador.IdEquipe = int.Parse(form["Equipe"]!);

            if(novoJogador.IdEquipe == 0){
                novoJogador.Equipe.ImagemEquipe = "imagem_padrao.png";
            }else{
                Equipe equipeSelecionada = new Equipe();
                equipeSelecionada = bancoDeDados.Equipe.First(x => x.IdEquipe == novoJogador.IdEquipe);
                novoJogador.Equipe = equipeSelecionada;
            }

            bancoDeDados.Jogador.Add(novoJogador);

            bancoDeDados.SaveChanges();

            return LocalRedirect("~/Jogador/ListaDeJogadores");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            Jogador jogadorBuscado = bancoDeDados.Jogador.First(x => x.IdJogador == id);

            bancoDeDados.Jogador.Remove(jogadorBuscado);

            bancoDeDados.SaveChanges();

            return LocalRedirect("~/Jogador/ListaDeJogadores");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id){
            //Tras os dados do usuario
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Equipe = bancoDeDados.Equipe.ToList();
            ViewBag.Jogador = bancoDeDados.Jogador.First(x => x.IdJogador == id);
            return View();
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form){
            Jogador novoJogador = new Jogador();

            novoJogador.IdJogador = int.Parse(form["IdJogador"]!);
            novoJogador.NomeJogador = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha = form["Senha"];
            novoJogador.IdEquipe = int.Parse(form["Equipe"]!);

            Jogador jogadorEditado = bancoDeDados.Jogador.First(x => x.IdJogador == novoJogador.IdJogador);

            jogadorEditado.NomeJogador = novoJogador.NomeJogador;
            jogadorEditado.Email = novoJogador.Email;
            jogadorEditado.Senha = novoJogador.Senha;
            jogadorEditado.IdEquipe = novoJogador.IdEquipe;

            bancoDeDados.Jogador.Update(jogadorEditado);

            bancoDeDados.SaveChanges();

            return LocalRedirect("~/Jogador/ListaDeJogadores");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}