using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        private IComentariosEventoRepository _comentariosRepository { get; set; }

        private readonly ContentModeratorClient _contentModeratorClient;

        //construtor da IA
        public ComentariosEventoController(ContentModeratorClient contentModerator)
        {
            _comentariosRepository = new ComentariosEventoRepository();
            _contentModeratorClient = contentModerator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try {

                List<ComentariosEvento> todosComentarios = _comentariosRepository.Listar();

                return Ok(todosComentarios);

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);    
            }
        }

        [HttpGet("ListarPorUsuarioEvento")]
        public IActionResult GetByUserEvent(Guid idUsuario, Guid idEvento)
        {
            try
            {
                List<ComentariosEvento> comentariosUsuarioEvento = _comentariosRepository.ListarPorUsuarioEvento(idUsuario, idEvento);

                if(comentariosUsuarioEvento == null)
                {
                    return NotFound("Não há comentário");
                }

                return Ok(comentariosUsuarioEvento);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarSomenteExibe/{id}")]
        public IActionResult GetOnlyShowTrue(Guid id)
        {
            try {
                List<ComentariosEvento> comentariosSomenteExibe = _comentariosRepository.ListarSometeExibe(id);

                return Ok(comentariosSomenteExibe);
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarComentariosPorEvento/{id}")]
        public IActionResult GetByEvent(Guid id) {
            try
            {
                List<ComentariosEvento> comentariosDoEvento = _comentariosRepository.ListarPorIdEvento(id);

                if(comentariosDoEvento == null)
                {
                    return NotFound("Não há comentários para o evento");
                }

                return Ok(comentariosDoEvento);
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ComentariosEvento novoComentario)
        {
            try
            {
                if (string.IsNullOrEmpty(novoComentario.Descricao))
                {
                    return BadRequest("Não há como cadastrar um comentário vazio");
                }

                //converte a string(descrição do comentário) em um MemoryStream
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(novoComentario.Descricao));

                //realiza a moderação do conteúdo
                var moderationResult = await _contentModeratorClient.TextModeration.ScreenTextAsync("text/plain", stream, "por", false, false, null, true);


                //moderationResult.Terms != null ? novoComentario.Exibe = false : novoComentario.Exibe = true;
                //se existir termos ofensivos, não mostrar(exibe = false)
                if (moderationResult.Terms != null)
                {
                    novoComentario.Exibe = false;
                    
                }
                else
                {
                    novoComentario.Exibe = true;
                }

                _comentariosRepository.Cadastrar(novoComentario);

                return StatusCode(201, novoComentario);
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosRepository.Deletar(id);

                return StatusCode(204, "Comentário deletado com sucesso");
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
