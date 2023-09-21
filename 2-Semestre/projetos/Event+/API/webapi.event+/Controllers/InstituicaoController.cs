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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;
        public InstituicaoController()
        {
            _instituicaoRepository= new InstituicaoRepository();
        }
        
        /// <summary>
        /// Rota para listar todas as instituições cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Instituicao> listaDeInstituicoes = _instituicaoRepository.ListarInstituicoes();

                return Ok(listaDeInstituicoes);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para buscar determinada estituição pelo seu id
        /// </summary>
        /// <param name="id">Id do estúdio a ser buscado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarInstituicao(id);

                if(instituicaoBuscada != null)
                {
                    return Ok(instituicaoBuscada);
                }
                else
                {
                    return NotFound("Não existe instituição cadastrada com o id informado");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Rota para cadastrar uma nova instituição
        /// </summary>
        /// <param name="instituicao">Informações da instituição que será cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return Ok("Instituição cadastrada com sucesso!");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Rota para deletar determinada instituição pelo seu id
        /// </summary>
        /// <param name="id">Id da instituição a ser deletada</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarInstituicao(id);

                if (instituicaoBuscada != null)
                {
                    _instituicaoRepository.DeletarInstituicao(id);

                    return Ok("Instituição deletada com sucesso!");
                }
                else
                {
                    return NotFound("Não existe instituição cadastrada com o id informado");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Rota para atualizar determinada instituição
        /// </summary>
        /// <param name="id">Id da instituição a ser atualizada</param>
        /// <param name="instituicao">Novas informações da instituição</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Guid id, Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarInstituicao(id);

                if (instituicaoBuscada != null)
                {
                    _instituicaoRepository.AtualizarInstituicao(id, instituicao);

                    return Ok("Instituição atualizada com sucesso!");
                }
                else
                {
                    return NotFound("Não existe instituição cadastrada com o id informado");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
