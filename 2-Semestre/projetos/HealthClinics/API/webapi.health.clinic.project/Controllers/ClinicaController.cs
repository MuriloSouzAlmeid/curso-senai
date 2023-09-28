using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using webapi.health.clinic.project.Domains;
using webapi.health.clinic.project.Interfaces;
using webapi.health.clinic.project.Repositories;

namespace webapi.health.clinic.project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaRepository _clinicaRepository;
        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Rota para listar todas as clínicas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Clinica> listaDeClinicas = _clinicaRepository.Listar();

                return Ok(listaDeClinicas);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar uma nova clínica
        /// </summary>
        /// <param name="novaClinica">informações da clínica a ser cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return Ok("Clínica cadastrada com sucesso");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Rota para deletar determinada clínica pelo seu id
        /// </summary>
        /// <param name="id">Id da clínica a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);

                if(clinicaBuscada == null)
                {
                    return NotFound("Não existe clínica cadastrada com o id informado");
                }

                _clinicaRepository.Deletar(id);

                return Ok("Clínica deletada com sucesso");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinada clínica pelo seu id
        /// </summary>
        /// <param name="id">Id da clínica a ser atualizada</param>
        /// <param name="clinicaAtualizada">Novas informações da clínica em questão</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Clinica clinicaAtualizada)
        {
            try
            {
                Clinica clinicaBuscada = _clinicaRepository.BuscarPorId(id);

                if (clinicaBuscada == null)
                {
                    return NotFound("Não existe clínica cadastrada com o id informado");
                }

                _clinicaRepository.Atualizar(id, clinicaAtualizada);

                return Ok("Clínica deletada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
