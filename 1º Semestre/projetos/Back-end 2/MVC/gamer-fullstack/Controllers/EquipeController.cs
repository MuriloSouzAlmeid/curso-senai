using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gamer_fullstack.infra;
using gamer_fullstack.Models;

namespace gamer_fullstack.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        //Objeto da classe Context para poder acessar o banco de dados
        Context bancoDeDados = new Context();

        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        //Criar a Action do controller
                                                                                              //controller/action
        [Route("ListaDeEquipes")] // é como se fosse o caminho/rota de um arquivo -> https://localhost/Equipe/ListaDeEquipes
        // Um método chama o método view
        public IActionResult Index()
        {
            //Trás os dados do usuario
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
                             //Lista os itens na tabala de equipes. Sintaxe -> nomeDaTabela.ToList()
            ViewBag.Equipe = bancoDeDados.Equipe.ToList();
            //Bolsa que guarda as equipes que foram listadas. Sintaxe -> ViewBag.nomeDaTabela
            //Podemos usar essa bolsa na view de Equipe -> Retorna uma Lista de objetos da classe especificada

            //Retorna a View de Equipe
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Equipe novaEquipe = new Equipe();

            //Dentro do form temos o nome do campo no input html. Sintaxe form["Nome do campo"]
            novaEquipe.NomeEquipe = form["Nome"].ToString();

            //Anexando Imagens
            // novaEquipe.ImagemEquipe = form["Imagem"].ToString();

            //Subindo upload de imagem
            if(form.Files.Count > 0){
                //Isso acontece porque os arquivos enviados pelo formulário são retornados em uma lista que pode ser acessada pela classe Files
                //Guarda o arquivo em uma variável sem tipo
                var file = form.Files[0];

                //Path.Combine junta várias string e forma um único caminho/path
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipe");

                //Cria o caminho caso não exista
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                //Gera o caminho da imagem já com o diretório e nome completo
                var path = Path.Combine(folder, file.FileName);

                //Vou pesquisar depois
                using(var stream = new FileStream(path, FileMode.Create)){
                    file.CopyTo(stream);
                }
                novaEquipe.ImagemEquipe = file.FileName;

            }else{
                novaEquipe.ImagemEquipe = "imagem_padrao.png";
            }

            bancoDeDados.Equipe.Add(novaEquipe);

            //Salva as alterações no objeto de banco de dados
            bancoDeDados.SaveChanges();

            //Não há a necessidade de salvar na lista novamente pelo motivo que a mesma já será chamada no método de ListaDeEquipes
            // ViewBag.Equipe = bancoDeDados.Equipe.ToList();

            //Redireciona para essa url
            return LocalRedirect("~/Equipe/ListaDeEquipes");
        }

        //Removendo Usuários
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            bancoDeDados.Equipe.Remove(bancoDeDados.Equipe.First(x => x.IdEquipe == id));

            bancoDeDados.SaveChanges();

            return LocalRedirect("~/Equipe/ListaDeEquipes");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id){
            //Tras os dados do usuario
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
             
            Equipe equipeGuardada = bancoDeDados.Equipe.First(x => x.IdEquipe == id);

            ViewBag.Equipe = equipeGuardada;

            return View("Edit");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form, Equipe equipe){
            Equipe novaEquipe = new Equipe();

            novaEquipe.NomeEquipe = form["Nome"];
            if(form.Files.Count > 0){
                var file = form.Files[0];

                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipe");

                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using(var stream = new FileStream(path, FileMode.Create)){
                    file.CopyTo(stream);
                }

                novaEquipe.ImagemEquipe = file.FileName;
            }else{
                novaEquipe.ImagemEquipe = "imagem_padrao.png";
            }

            Equipe equipeEncontrada = bancoDeDados.Equipe.First(x => x.IdEquipe == equipe.IdEquipe);

            equipeEncontrada.NomeEquipe = novaEquipe.NomeEquipe;
            equipeEncontrada.ImagemEquipe = novaEquipe.ImagemEquipe;

            bancoDeDados.Equipe.Update(equipeEncontrada);

            bancoDeDados.SaveChanges();

            return LocalRedirect("~/Equipe/ListaDeEquipes");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}