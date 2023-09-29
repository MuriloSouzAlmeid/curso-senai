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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoController()
        {
            this._medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Rota para listar todos os médicos cdstrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Medico> listaDeMedicos = _medicoRepository.Listar();

                return Ok(listaDeMedicos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar um novo médico
        /// </summary>
        /// <param name="novoMedico">Informações do médico a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                _medicoRepository.Cadastrar(novoMedico);

                return Ok("Médico cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinado médico pelo seu id
        /// </summary>
        /// <param name="id">Id do médico a ser atualizado</param>
        /// <param name="medicoAtualizado">Novas informações do médico em questão</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Medico medicoAtualizado)
        {
            try
            {
                Medico medicoBuscado = _medicoRepository.BuscarPorId(id);

                if (medicoBuscado != null)
                {
                    _medicoRepository.Atualizar(id, medicoAtualizado);

                    return Ok("Médico atualizado com sucesso");
                }

                return NotFound("Não há médico cadastrado com o id informado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}