using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoCOntroller : ControllerBase
    {
        private IComentariosEventoRepository _comentariosRepository { get; set; } = new ComentariosEventoRepository();

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
        public IActionResult GetOnlyShowTrue(Guid idEvento)
        {
            try {
                List<ComentariosEvento> comentariosSomenteExibe = _comentariosRepository.ListarSometeExibe(idEvento);

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
        public IActionResult Post(ComentariosEvento novoComentario)
        {
            try
            {
                _comentariosRepository.Cadastrar(novoComentario);

                return Ok(novoComentario);
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
