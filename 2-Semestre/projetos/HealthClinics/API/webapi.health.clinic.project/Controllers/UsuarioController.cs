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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            this._usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Rota para cadastrar um novo usuário 
        /// </summary>
        /// <param name="novoUsuario">informações do usuário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return Ok("Usuário cadastrado com sucesso!");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para deletar determinado usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if(usuarioBuscado != null)
                {
                    _usuarioRepository.Deletar(id);

                    return Ok("Usuário deletado com sucesso");
                }

                return NotFound("Não há usuário cadastrado com o Id informado");

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinado usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado</param>
        /// <param name="usuarioAtualizado">Novas informaçãoes do usuário em questão</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);

                    return Ok("Usuário atualizado com sucesso");
                }

                return NotFound("Não há usuário cadastrado com o Id informado");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
