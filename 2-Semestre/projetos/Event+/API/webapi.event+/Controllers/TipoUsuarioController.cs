using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]    
    public class TipoUsuarioController : ControllerBase
    {
        private string IdNaoEncontrado { get; set; } = "Não existe algum tipo de usuário cadastrado com o id informado";
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Rota para listar todos os Tipos de Usuário cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuario = _tipoUsuarioRepository.Listar();

                return StatusCode(200,listaTipoUsuario);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para buscar determinado tipo de usuário cadatrado pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuário a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if(tipoUsuarioBuscado != null)
                {
                    return Ok(tipoUsuarioBuscado);
                }
                else
                {
                    return NotFound(IdNaoEncontrado);
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto contendo as informações do tipo de usuário
        /// a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201, "Tipo de usuário cadastrado com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para deletar determinado tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                TipoUsuario tipoBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if(tipoBuscado != null)
                {
                    _tipoUsuarioRepository.Deletar(id);

                    return Ok("Tipo de usuário deletdo com sucesso");
                }
                else
                {
                    return NotFound(IdNaoEncontrado);
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinado tipo de tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id">Id dotipo de usuário a ser deletado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto contendo as informações atualizadas do objeto a ser atualiado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Delete(Guid id, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                TipoUsuario tipoBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if(tipoBuscado != null)
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                    return Ok("Tipo de usuário atualizado com sucesso");
                }
                else
                {
                    return BadRequest(IdNaoEncontrado);
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
