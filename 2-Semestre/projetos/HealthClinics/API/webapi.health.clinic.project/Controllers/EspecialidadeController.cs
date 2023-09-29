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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;
        public EspecialidadeController()
        {
            this._especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Rota para listar todas as especialidades cadastradas assim como os médicos que as possuem
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Especialidade> listaDeEspecialidades = _especialidadeRepository.Listar();

                return Ok(listaDeEspecialidades);
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota para cadastrar uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Informações da especialidade a ser cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(novaEspecialidade);

                return Ok("Especialidade médica cadastrada com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota para atualizar determinada especialidade pel seu id
        /// </summary>
        /// <param name="id">Id da especialidade a ser deletada</param>
        /// <param name="especialidadeAtualizada">Novas informações da especialidade em questão</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Especialidade especialidadeAtualizada)
        {
            try
            {
                Especialidade especialidadeBUscada = _especialidadeRepository.BuscarPorId(id);

                if(especialidadeBUscada != null)
                {
                    _especialidadeRepository.Atualizar(id, especialidadeAtualizada);

                    return Ok("Especialidade médica cadastrada com sucesso");
                }

                return NotFound("Não há especialidade cadastrada com o id informado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
