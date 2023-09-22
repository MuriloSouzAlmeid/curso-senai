using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;
        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }

        /// <summary>
        /// Rota para listar todos os tipos de evento cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TipoEvento> listaDeTipos = _tipoEventoRepository.Listar();

                return Ok(listaDeTipos);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para buscar determinado tipo de evento pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de estúdio a ser cadastrado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipoBuscado = _tipoEventoRepository.BuscarPorId(id);

                if(tipoBuscado == null)
                {
                    return NotFound("Não há tipo de evento cadastrado com o id informado");
                }

                return Ok(tipoBuscado);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="novoTipo">Informações do novo tipo de evento a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TipoEvento novoTipo)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipo);

                return Ok("Tipo de evento cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para deletar determinado tipo de evento pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de evento a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                TipoEvento tipoBuscado = _tipoEventoRepository.BuscarPorId(id);

                if (tipoBuscado == null)
                {
                    return NotFound("Não há tipo de evento cadastrado com o id informado");
                }

                _tipoEventoRepository.Deletar(id);

                return Ok("O tipo de evento foi deletado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinado tipo de evento pelo seu id
        /// </summary>
        /// <param name="id">Id do evento a ser atualizado</param>
        /// <param name="tipoAtualizado">Novas informações do tipo de evento em questão</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, TipoEvento tipoAtualizado)
        {
            try
            {
                TipoEvento tipoBuscado = _tipoEventoRepository.BuscarPorId(id);

                if (tipoBuscado == null)
                {
                    return NotFound("Não há tipo de evento cadastrado com o id informado");
                }

                _tipoEventoRepository.Atualizar(id, tipoAtualizado);

                return Ok("O tipo de evento foi atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
