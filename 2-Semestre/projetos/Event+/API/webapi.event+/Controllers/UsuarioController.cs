using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Rota para cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto contendo as informações do usuário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, "Usuário cadastrado com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para buscar determinado usuário por seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if(usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                else
                {
                    return NotFound("Não foi encontrado usuário cadastrado com o id informado");
                }
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

                if(usuarioBuscado == null)
                {
                    return NotFound("Não foi encontrado usuário cadastrado com o id informado");
                }
                else
                {
                    _usuarioRepository.Deletar(id);

                    return Ok("Usuário deletado com sucesso.");
                }
            }catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinado usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser atualizado</param>
        /// <param name="usuarioAtualizado">Objeto contendo as novas informações do usuário</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if(usuarioBuscado != null)
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);

                    return Ok("Usuário atualizado com sucesso.");
                }
                else
                {
                    return NotFound("Não foi encontrado usuário cadastrado com o id informado");
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
