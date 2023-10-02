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
    public class ProntuarioConsultaController : ControllerBase
    {
        private readonly IProntuarioConsultaRepository _prontuarioConsultaRepository;
        public ProntuarioConsultaController()
        {
            this._prontuarioConsultaRepository = new ProntuarioConsultaRepository();
        }

        /// <summary>
        /// Rota para cadastrar um prontuário para uma consulta
        /// </summary>
        /// <param name="novoProntuario">Informações do prontuário</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ProntuarioConsulta novoProntuario)
        {
            try
            {
                _prontuarioConsultaRepository.Cadastrar(novoProntuario);

                return Ok("Prontuário inserido com sucesso");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar um prontuário de uma consulta
        /// </summary>
        /// <param name="id">Id do prontuário a ser atualizado</param>
        /// <param name="prontuarioAtualizado">Novas informações do prontuário a ser atualizado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ProntuarioConsulta prontuarioAtualizado)
        {
            try
            {
                ProntuarioConsulta prontuarioBuscado = _prontuarioConsultaRepository.BuscarPorId(id);
                
                if(prontuarioBuscado == null)
                {
                    return NotFound("Não há prontuário com o id inserido em nenhuma consulta agendada");
                }

                _prontuarioConsultaRepository.Atualizar(id, prontuarioAtualizado);

                return Ok("Prontuário atualizado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
