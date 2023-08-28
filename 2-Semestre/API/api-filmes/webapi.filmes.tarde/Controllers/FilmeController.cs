using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        //Mensagem que aparecerá caso o id especiicado não seja encontrado
        private string IdNaoEncontrado = "Não existe filme cadastrado com o Id informado";

        //Mensagem personalizada que aparecerá caso a operção seja bem sucedida
        private string OperacaoBemSucedida(string operacao)
        {
            return $"Filme {operacao} com sucesso.";
        }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método de listar todos os filmes
        /// </summary>
        /// <returns>Lista com todos os filmes cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaDeFilmes = new List<FilmeDomain>();
                listaDeFilmes = _filmeRepository.ListarFilmes();

                return StatusCode(200, listaDeFilmes);
            }
            catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de buscar determinado filme pelo seu Id
        /// </summary>
        /// <param name="id">Id do filme a ser buscado</param>
        /// <returns>O status code da requisição junto das informações do filme buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filme = _filmeRepository.BurcarPorId(id);

                if (filme == null)
                {
                    return StatusCode(404, this.IdNaoEncontrado);
                }
                else
                {
                    return StatusCode(200, filme);
                }
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de cadastrar um novo filme
        /// </summary>
        /// <param name="filme">Objeto contendo as informações do novo filme</param>
        [HttpPost]
        public IActionResult Post(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.CadastrarFilme(filme);

                return StatusCode(201, this.OperacaoBemSucedida("cadastrado"));

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de deletar determinado filme pelo seu id
        /// </summary>
        /// <param name="id">Id do filme a ser deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                FilmeDomain filme = _filmeRepository.BurcarPorId(id);

                if(filme == null) {
                    return StatusCode(404, this.IdNaoEncontrado);
                }
                else { 

                    _filmeRepository.DeletarFilme(id);

                    return StatusCode(200, this.OperacaoBemSucedida("deletado"));
                }
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método para atualizar um filme existente
        /// </summary>
        /// <param name="filme">Objeto com as novas informações do filme</param>
        [HttpPut]
        public IActionResult Put(FilmeDomain filme)
        {
            try
            {
                _filmeRepository.AtualizarPeloCorpo(filme);

                return StatusCode(200, this.OperacaoBemSucedida("atualizado"));
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método para atualizar o filme pela url
        /// </summary>
        /// <param name="id">Id do filme a ser atualizado passado pela url</param>
        /// <param name="filmeAtualizado">Objeto com as novas informações do filme</param>
        [HttpPut("{id}")]
        public IActionResult PutByUrl(int id, FilmeDomain filmeAtualizado)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BurcarPorId(id);

                if (filmeBuscado == null)
                {
                    return StatusCode(404, this.IdNaoEncontrado);
                }
                else
                {
                    _filmeRepository.AtualizarPelaUrl(id, filmeAtualizado);

                    return StatusCode(200, this.OperacaoBemSucedida("atualizado"));
                }
            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
