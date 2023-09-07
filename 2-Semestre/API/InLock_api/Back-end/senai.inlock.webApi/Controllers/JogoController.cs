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
        //mensagem para caso o jogo não seja encontrado com o id
        public string NaoEncontrado = "Não existe jogo cadastrado com o id informado";

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
        /// Rota responsável por buscar determinado jogo por seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser buscado</param>
        /// <returns>StatusCode da requisição junto de um objeto contendo as informações do jogo buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository.BuscarJogoPorId(id);

                if (jogoBuscado != null)
                {
                    return Ok(jogoBuscado);
                }
                else
                {
                    return NotFound(NaoEncontrado);
                }
            }
            catch (Exception erro)
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

        /// <summary>
        /// Rota responsável por deletar determinado jogo pelo seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser deletado</param>
        /// <returns>StatusCode da requisição</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Delete(int id)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository.BuscarJogoPorId(id);

                if(jogoBuscado != null)
                {
                    _jogoRepository.DeletarJogo(id);

                    return Ok("Jogo deletado com sucesso");
                }
                else
                {
                    return NotFound(NaoEncontrado);
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por atualizar determinado jogo recebendo as informações pelo corpo da requisição
        /// </summary>
        /// <param name="jogoAtualizado">Objeto contendo o id e as novas informações do jogo a ser atualizado</param>
        /// <returns>StatusCode da requisição</returns>
        [HttpPut]
        [Authorize(Roles = "2")]
        public IActionResult PutByBody(JogoDomain jogoAtualizado)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository.BuscarJogoPorId(jogoAtualizado.IdJogo);

                if (jogoBuscado != null)
                {
                    _jogoRepository.AtualizarJogoPorCorpo(jogoAtualizado);

                    return Ok("Jogo Atualizado com Sucesso");
                }
                else
                {
                    return NotFound(NaoEncontrado);
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por atualizar um jogo com seu id passado pela url e suas novas informações passadas pelo corpo da requisição
        /// </summary>
        /// <param name="id">Id do jogo a ser atualizado</param>
        /// <param name="jogoAtualizado">Objeto contendo as novas informações do jogo a serem atualizadas</param>
        /// <returns>StatusCode da requisição</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult PutByUrl(int id, JogoDomain jogoAtualizado)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository.BuscarJogoPorId(id);

                if (jogoBuscado != null) 
                {
                    _jogoRepository.AtualizarJogoPelaUrl(id,jogoAtualizado);

                    return Ok("Jogo Atualizado com Sucesso");
                }
                else
                {
                    return NotFound(NaoEncontrado);
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
