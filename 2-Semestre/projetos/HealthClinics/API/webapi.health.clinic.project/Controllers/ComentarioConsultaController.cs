using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;
using webapi.health.clinic.project.Repositories;

namespace webapi.health.clinic.project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioConsultaController : ControllerBase
    {
        private readonly IComentarioConsultaRepository _comentarioConsultaRepository;
        public ComentarioConsultaController()
        {
            this._comentarioConsultaRepository = new ComentarioRepository();
        }

        /// <summary>
        /// Rota para cadastrar um novo comentário para uma consulta
        /// </summary>
        /// <param name="novoComentario">Informações do comentário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ComentarioConsulta novoComentario)
        {
            try
            {
                _comentarioConsultaRepository.Cadastrar(novoComentario);

                return Ok("Comentário cadastrado com sucesso");

            }catch(Exception erro){

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota para deletar um comentário cadastrado
        /// </summary>
        /// <param name="id">Id do comentário a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                ComentarioConsulta comentarioBuscado = _comentarioConsultaRepository.BuscarPorId(id);

                if(comentarioBuscado == null)
                {
                    return NotFound("Não há comentátio cadastrado com o id informado");
                }

                _comentarioConsultaRepository.Deletar(id);

                return Ok("Comentário deletado com sucesso");

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
