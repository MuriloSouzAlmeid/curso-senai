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
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;
        public ConsultaController()
        {
            this._consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Rota para listar todas as consultas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Consulta> listaDeConsultas = _consultaRepository.ListarTodas();
                
                return Ok(listaDeConsultas);
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota para listar as consultas associadas a um determinado usuário pelo seu id
        /// </summary>
        /// <param name="id">Id do usuário associado à consulta</param>
        /// <returns></returns>
        [HttpGet("ListarMinhas")]
        public IActionResult GetByUser(Guid id)
        {
            try
            {
                List<Consulta> listaDeConsultas = _consultaRepository.BuscarMinhas(id);

                return Ok(listaDeConsultas);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota para agendar uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Informações da consulta a ser agendada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return Ok("Consulta agendada com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cancelar determinada consulta agendada pelo seu id
        /// </summary>
        /// <param name="id">id da consulta a ser cancelada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);

                if (consultaBuscada == null)
                {
                    return NotFound("Não há consulta cadastrada com o id informado");
                }

                _consultaRepository.Deletar(id);

                return Ok("Consulta cancelada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar os dados de uma consulta agendada pelo seu id
        /// </summary>
        /// <param name="id">Id da consulta a ser atualizada</param>
        /// <param name="consultaAtualizada">Novas informações da consulta em questão</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Consulta consultaAtualizada)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);

                if (consultaBuscada == null)
                {
                    return NotFound("Não há consulta cadastrada com o id informado");
                }
                _consultaRepository.Atualizar(id, consultaAtualizada);

                return Ok("Dados da consulta atualizados com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
