using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    //define o nome do endpoint
    [Route("api/[controller]")]
    //define que isso é um controller
    [ApiController]
    //define que o corpo da requisição será em formato json
    [Produces("application/json")]
    //define que é necessário estar autenticado para acessar às rotas deste Controller
    [Authorize]
    public class JogoController : ControllerBase
    {
        //cria o objeto que conterá os métodos necessários
        private IJogoRepository _jogoRepository { get; set; }

        //atribui os métodos para o objeto _jogoRepository
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Rota responsável por listar todos os jogos cadastrados em uma tabela
        /// </summary>
        /// <returns>Status code da requisição</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List <JogoDomain> listaJogos = _jogoRepository.ListarJogos();

                return StatusCode(200, listaJogos);
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por cadastrar um novo jogo na tabela Jogo
        /// </summary>
        /// <param name="novoJogo">Objeto contendo as informações do jogo que será cadastrado</param>
        /// <returns>Status code da requisição</returns>
        [HttpPost]
        //Define que apenas usuários com IdTipoUsuario = 2 (Administradores) podem acessar essa rota
        [Authorize(Roles = "2")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.CadastrarJogo(novoJogo);

                return Ok("Jogo cadastrado com sucesso");
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
