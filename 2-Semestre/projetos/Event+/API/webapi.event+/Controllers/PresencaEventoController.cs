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
    public class PresencaEventoController : ControllerBase
    {
        private readonly IPresencaEventoRepository _presencaEventoRepository;
        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }

        /// <summary>
        /// Rota para listar todas as inscrições em eventos cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<PresencaEvento> listaDePresencas = _presencaEventoRepository.Listar();

                return Ok(listaDePresencas);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota buscar determinada inscrição em algum evento pelo seu id
        /// </summary>
        /// <param name="id">Id do evento a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscada = _presencaEventoRepository.BuscarPorId(id);

                if(presencaBuscada == null)
                {
                    return NotFound("Não há inscrição cadastrada com o id informado");
                }

                return Ok(presencaBuscada);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para listar todas as inscrições associadas a determinado aluno pelo seu id
        /// </summary>
        /// <param name="id">Id do aluno associado às inscrições</param>
        /// <returns></returns>
        [HttpGet("ListarMinhas/{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetByUser(Guid id)
        {
            try
            {
                List<PresencaEvento> listaPresenca = _presencaEventoRepository.ListarMinhas(id);

                return Ok(listaPresenca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para realizar uma inscrição de um aluno em um evento
        /// </summary>
        /// <param name="novaPresenca">Informações do aluno, do evento e da situação da inscrição para o cadastro</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(PresencaEvento novaPresenca)
        {
            try
            {
                _presencaEventoRepository.Inscrever(novaPresenca);

                return Ok("Inscrição realizada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cancelar determinada inscrição de um aluno em um evento pelo id da inscrição
        /// </summary>
        /// <param name="id">Id da inscrição a ser cancelada</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscada = _presencaEventoRepository.BuscarPorId(id);

                if (presencaBuscada == null)
                {
                    return NotFound("Não há inscrição cadastrada com o id informado");
                }

                _presencaEventoRepository.Deletar(id);

                return Ok("Inscrição deletada com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar as iformações de determinada inscrição pelo seu id
        /// </summary>
        /// <param name="id">Id da inscrição a ser atualizada</param>
        /// <param name="presencaAtualizada">Informaações atualizadas da inscrição</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, PresencaEvento presencaAtualizada)
        {
            try
            {
                PresencaEvento presencaBuscada = _presencaEventoRepository.BuscarPorId(id);

                if (presencaBuscada == null)
                {
                    return NotFound("Não há inscrição cadastrada com o id informado");
                }

                _presencaEventoRepository.Atualizar(id, presencaAtualizada);

                return Ok("Inscrição atualizada com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
