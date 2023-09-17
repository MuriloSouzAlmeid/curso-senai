using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repositories;
using webapi.inlock.codefirst.ViewModels;

namespace webapi.inlock.codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Rota para listar todos os jogos cadastrados junto de seus estúdios
        /// </summary>
        /// <returns>Lista com todos os jogos cadastrados</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_jogoRepository.ListarJogos());
            }catch(Exception e)
            {
                return BadRequest(e.Message);  
            }
        }

        /// <summary>
        /// Rota para buscar um jogo pelo seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser buscado</param>
        /// <returns>Jogo buscado pelo id informado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.BuscarJogoPorId(id);

                if(jogoBuscado == null)
                {
                    return NotFound("Não existe jogo cadastrado com o id informado");
                }
                else
                {
                    return Ok(jogoBuscado);
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo jogo
        /// </summary>
        /// <param name="informacoesJogo">Informações do jogo a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(JogoViewModel informacoesJogo)
        {
            try
            {
                Jogo novoJogo = new Jogo() 
                {
                    Nome = informacoesJogo.Nome,
                    Descricao = informacoesJogo.Descricao,
                    DataLancamento = informacoesJogo.DataLancamento,
                    Preco = informacoesJogo.Preco,
                    IdEstudio = informacoesJogo.IdEstudio
                };

                _jogoRepository.CadastrarJogo(novoJogo);

                return Ok("Jogo cadastrado com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para deletar determinado jogo pelo seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser deletado</param>
        /// <returns>StatusCode da requisição</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.BuscarJogoPorId(id);

                if(jogoBuscado != null)
                {
                    _jogoRepository.DeletarJogoPorId(id);

                    return Ok("O jogo foi deletado com sucesso");
                }
                else
                {
                    return NotFound("Não existe jogo cadastrado com o id informado");
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar um jogo pelo seu is
        /// </summary>
        /// <param name="id">id do jogo a ser atualizado</param>
        /// <param name="informacoesJogo">Objeto contendo as novas informações do jogo</param>
        /// <returns>StatusCode da requisição</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, JogoViewModel informacoesJogo)
        {
            try
            {
                Jogo jogoBuscado = _jogoRepository.BuscarJogoPorId(id);

                if(jogoBuscado == null)
                {
                    return NotFound("Não existe jogo cadastrado com o id informado");
                }

                Jogo jogo = new Jogo() 
                {
                    Nome = informacoesJogo.Nome,
                    Descricao = informacoesJogo.Descricao,
                    DataLancamento = informacoesJogo.DataLancamento,
                    Preco = informacoesJogo.Preco,
                    IdEstudio = informacoesJogo.IdEstudio
                };

                _jogoRepository.AtualizarJogoPorId(id, jogo);

                return Ok("Jogo atualizado com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
