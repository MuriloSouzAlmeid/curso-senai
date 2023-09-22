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
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Rota para listar todos os eventos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Evento> listaDeEventos = _eventoRepository.Listar();

                return Ok(listaDeEventos);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para Buscar determinado evento pelo seu id
        /// </summary>
        /// <param name="id">Id do evento a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if(eventoBuscado != null)
                {
                    return Ok(eventoBuscado);
                }

                return NotFound("Não foi encontrado evento com o id informado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo evento
        /// </summary>
        /// <param name="novoEvento">Informações do evento a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);

                return Ok("Evento cadastrado com sucesso.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para deletar determinado evento pelo seu id
        /// </summary>
        /// <param name="id">Id do evento a ser deletado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    _eventoRepository.Deletar(id);

                    return Ok("O evento foi deletado com sucesso.");
                }

                return NotFound("Não foi encontrado evento com o id informado");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinado evento pelo seu id
        /// </summary>
        /// <param name="id">Id do evento a ser atualizado</param>
        /// <param name="eventoAtualizado">Novas informações do evento em questão</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Evento eventoAtualizado)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    _eventoRepository.Atualizar(id, eventoAtualizado);

                    return Ok("Evento atualizado com sucesso");
                }

                return NotFound("Não foi encontrado evento com o id informado");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
