using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService mongoDbService)
        {
            //acessa a collection com nome product nno banco de dados e referencia na variável _product
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();
                return Ok(products);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

                Product produtoBuscado = await _product.Find(filter).FirstOrDefaultAsync();

                if(produtoBuscado == null)
                {
                    return NotFound("Produto não encontrado");
                }

                return Ok(produtoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product produtoInfo)
        {
            try
            {
                Product novoProduto = new Product() {
                    Name = produtoInfo.Name,
                    Price = produtoInfo.Price,
                    AdditionalAttributes = produtoInfo.AdditionalAttributes
                };

                await _product.InsertOneAsync(novoProduto);

                return Ok(novoProduto);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

                Product produtoBuscado = await _product.Find(filter).FirstOrDefaultAsync();

                if (produtoBuscado == null)
                {
                    return NotFound("Produto não encontrado");
                }

                await _product.DeleteOneAsync(product => product.Id == id);
                return Ok("Deletado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]  Product produtoAtualizado)
        {
            try
            {
                var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

                List<Product> lista = await _product.Find(filter).ToListAsync();

                Product produtoBuscado = lista.First();

                if (produtoBuscado == null)
                {
                    return NotFound("Produto não encontrado");
                }

                if (produtoAtualizado.Name != null)
                {
                    produtoBuscado.Name = produtoAtualizado.Name; 
                }
                if(produtoAtualizado.Price != 0)
                {
                    produtoBuscado.Price = produtoAtualizado.Price;
                }
                if(produtoAtualizado.AdditionalAttributes != null){
                    produtoBuscado.AdditionalAttributes = produtoAtualizado.AdditionalAttributes;
                }

                var update = Builders<Product>.Update.Set(p => p.Name, produtoBuscado.Name)
                                                     .Set(p => p.Price, produtoBuscado.Price)
                                                     .Set(p => p.AdditionalAttributes, produtoBuscado.AdditionalAttributes);

                await _product.UpdateOneAsync(filter, update);

                return Ok("Atualizado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
