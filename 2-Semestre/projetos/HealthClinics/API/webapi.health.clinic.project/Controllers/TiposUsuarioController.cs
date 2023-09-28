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
    public class TiposUsuarioController : ControllerBase
    {
        private readonly ITiposUsuarioRepository _tiposUsuarioRepository;
        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TiposUsuario> listaDeTiposDeUsuarios = _tiposUsuarioRepository.ListarTiposDeUsuario();

                return Ok(listaDeTiposDeUsuarios);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Informações do novo tipo a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(novoTipo);

                return Ok("Tipo de usuário cadastrado com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
         
        /// <summary>
        /// Rota para deletar determinado tipo de usuário
        /// </summary>
        /// <param name="id">Id do tipo de usuário a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                TiposUsuario tipoBuscado = _tiposUsuarioRepository.BuscarPorId(id);

                if (tipoBuscado == null)
                {
                    return NotFound("Não foi encontrado um tipo de usuário com o id informado");
                }

                _tiposUsuarioRepository.Deletar(id);

                return Ok("Tipo de usuário deletado com sucesso");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
