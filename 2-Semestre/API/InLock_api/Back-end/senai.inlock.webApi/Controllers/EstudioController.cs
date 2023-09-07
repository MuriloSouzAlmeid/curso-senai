using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    //define o nome da rota/endpooint
    [Route("api/[controller]")]
    //define que esta rota é um controller
    [ApiController]
    //deine que as requisições e respostas passadas pelo corpo da rota serão em formato json
    [Produces("application/json")]
    //define que precisa estar autenticado para acessar as rotas presentes neste controller
    [Authorize]
    public class EstudioController : ControllerBase
    {
        //instancia o objeto que conterá os métodos necessários para a rota
        private IEstudioRepository _estudioRepository { get; set; }

        //atribui os métodos necessários para o objeto vazio
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Rota responsável por listar todos os estúdios cadastrados no banco de dados
        /// </summary>
        /// <returns>Status code da requisição e a lista dos estúdios</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //instancia a lista que receberá o retorno do método no repositório
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarEstudios();
                
                //retorna a lista com os estúdios
                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                //retorna uma requisição ruim com a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por buscar determinado estúdio pelo seu id
        /// </summary>
        /// <param name="id">Id do estúdio a ser buscado</param>
        /// <returns>O objeto com as informações do estúdio buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //instancia um objeto recebendo o valor do método de buscar por id
                EstudioDomain estudio = _estudioRepository.BuscarEstudioPorId(id);

                //verifica se o objeto retornado é válido ou nulo
                if (estudio != null)
                {
                    //caso o objeto buscado seja válido retorna um statuscode Ok(200) com o objeto encontrado
                    return Ok(estudio);
                }
                else
                {
                    //caso o objeto encontrado seja nulo retorna um statuscode NotFound(404) com a mensagem dizendo que o objeto não foi encontrado
                    return NotFound("O estúdio com o id informado não foi encontrado.");
                }

            }catch(Exception erro)
            {
                //caso de algum erro retorna uma request ruim informando também qual o erro que deu
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por cadastrar um novo estúdio no banco de dados
        /// </summary>
        /// <returns>Statuscode da requisição</returns>
        [HttpPost]
        //define que apenas administradores poderão acessar esta rota
        [Authorize(Roles = "2")]
        public IActionResult Post(EstudioDomain estudio)
        {
            try
            {
                _estudioRepository.CadastrarEstudio(estudio);

                return Ok("Estúdio cadastrado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por deletar determinado estúdio do banco de dados por seu id
        /// </summary>
        /// <param name="id">Id do estúdio a ser deletado</param>
        /// <returns>Statuscode da requisição</returns>
        [HttpDelete("{id}")]
        //deine que apenas administradores poserão acessar esta rota
        [Authorize(Roles = "2")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                //verifica se há algum estudio cadastrado com o id informado
                EstudioDomain estudioBuscado = _estudioRepository.BuscarEstudioPorId(id);

                //caso éxista um estúdio com o id informado deleta o estúdio
                if (estudioBuscado != null)
                {
                    //deleta o estúdio passando o id do mesmo como parâmetro
                    _estudioRepository.DeletarEstudio(id);

                    //retorna statuscode Ok com a mensagem bem sucedida
                    return Ok("Estúdio deletado com sucesso");
                }
                //caso não exista estúdio com o id informado
                else
                {
                    //retorna statuscode NotFound com a mensagem de fracasso
                    return NotFound("Não existe estúdio cadastrado com o id informado");
                }
            }
            //caso ocorra algum erro
            catch (Exception erro)
            {
                //retirna o status code de requisição ruim e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por atualizar as informações de um estúdio pelo corpo da requisição
        /// </summary>
        /// <param name="estudioAtualizado">Objeto contendo o id e as novas informações do estúdio a ser atualizado</param>
        /// <returns>Statuscod da requisição</returns>
        [HttpPut]
        [Authorize(Roles = "2")]
        public IActionResult PutByBody(EstudioDomain estudioAtualizado)
        {
            try
            {
                EstudioDomain estudioBuscado = _estudioRepository.BuscarEstudioPorId(estudioAtualizado.IdEstudio);

                if (estudioBuscado != null)
                {
                    _estudioRepository.AtualizarEstudioPeloCorpo(estudioAtualizado);

                    return Ok("Estúdio atualizado com sucesso");
                }
                else
                {
                    return NotFound("Não existe estúdio cadastrado com o id informado");
                }
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Rota responsável por atualizar as informações de um estúdio por seu id passado pela url
        /// </summary>
        /// <param name="id">id do estúdio a ser atualizado</param>
        /// <param name="estudioAtualizado">Objeto contendo as novas informações do estúdio a ser atualizado</param>
        /// <returns>Statuscode da requisição</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult PutByUrl(int id, EstudioDomain estudioAtualizado)
        {
            try
            {
                EstudioDomain estudioBuscado = _estudioRepository.BuscarEstudioPorId(id);

                if (estudioBuscado != null)
                {
                    _estudioRepository.AtualizarEstudioPorUrl(id,estudioAtualizado);

                    return Ok("Estúdio atualizado com sucesso");
                }
                else
                {
                    return NotFound("Não existe estúdio cadastrado com o id informado");
                }
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
