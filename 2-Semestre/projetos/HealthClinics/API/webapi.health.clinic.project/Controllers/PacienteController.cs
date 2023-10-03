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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteController()
        {
            this._pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Roota para listar todos os pacientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Paciente> ListaDePacientes = _pacienteRepository.Listar();

                return Ok(ListaDePacientes);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Informeções do paciente a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(novoPaciente);

                return Ok("Paciente cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinado paciente pelo seu id
        /// </summary>
        /// <param name="id">Id do paciente a ser atualizado</param>
        /// <param name="pacienteAtualizado">Novas informações do paciente</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Paciente pacienteAtualizado)
        {
            try
            {
                Paciente PacienteBusado = _pacienteRepository.BuscarPorId(id);

                if(PacienteBusado != null)
                {
                    _pacienteRepository.Atualizar(id, pacienteAtualizado);

                    return Ok("Usuario atualizado com sucesso");
                }

                return NotFound("Não há paciente cadastrado com o id informado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
