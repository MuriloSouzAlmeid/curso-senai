using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.Domains;
using ProductsWebAPI.Interfaces;
using ProductsWebAPI.Repositories;

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Products> produtos = _productsRepository.Get();

                return Ok(produtos);

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{idProduto}")]
        public IActionResult GetById(Guid idProduto)
        {
            try
            {
                Products produtoBuscado = _productsRepository.GetById(idProduto);

                if(produtoBuscado == null)
                {
                    return NotFound("Produto não encontrado");
                }

                return Ok(produtoBuscado);

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Products novoProduto)
        {
            try
            {
                Products produto = new Products() 
                {
                    Name = novoProduto.Name,
                    Price = novoProduto.Price
                };

                _productsRepository.Post(produto);

                return StatusCode(201, produto);

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{idProduto}")]
        public IActionResult Delete(Guid idProduto) 
        {
            try
            {
                Products produtoBuscado = _productsRepository.GetById(idProduto);

                if( produtoBuscado == null)
                {
                    return NotFound("Produto não encontrado");
                }

                _productsRepository.Delete(idProduto);

                return Ok("Produto deletado");

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{idProduto}")]
        public IActionResult Put(Guid idProduto, Products infoProduto)
        {
            try
            {
                Products produtoBuscado = _productsRepository.GetById(idProduto);

                if ( produtoBuscado == null)
                {
                    return NotFound("Produto não encontrado");
                }

                _productsRepository.Put(idProduto, infoProduto);

                return Ok("Produto atualizado");

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
