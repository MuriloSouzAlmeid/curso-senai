using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalAPIMongo.Domains;
using minimalAPIMongo.Services;
using minimalAPIMongo.ViewModels;
using MongoDB.Driver;

namespace minimalAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Users> _users;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("order");
            _users = mongoDbService.GetDatabase.GetCollection<Users>("users");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("client");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("product");
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            try
            {
                List<Order> listaDePedidos = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                return Ok(listaDePedidos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                Order pedidoBuscado = await _order.Find(o => o.Id == id).FirstOrDefaultAsync();

                if(pedidoBuscado == null)
                {
                    return NotFound("Pedido não encontrado");
                }

                return Ok(pedidoBuscado);

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderViewModel infoPedido)
        {
            try
            {
                Order novoPedido = new Order() { 
                    ClientId = infoPedido.ClientId,
                    Date = infoPedido.Date,
                    Status = infoPedido.Status,
                    ProductId = infoPedido.ProductsList
                };

                Client clienteBuscado = await _client.Find(c => c.Id == infoPedido.ClientId).FirstOrDefaultAsync();

                if(clienteBuscado == null)
                {
                    return NotFound("Cliente não encontrado");
                }

                novoPedido.Client = clienteBuscado;

                List<Product> listaDeProdutos = new List<Product>();

                if(novoPedido.ProductId != null)
                {
                    foreach (string idProduto in novoPedido.ProductId!)
                    {
                        Product produtoBuscado = await _product.Find(p => p.Id == idProduto).FirstOrDefaultAsync();

                        if(produtoBuscado != null)
                        {
                            listaDeProdutos.Add(produtoBuscado);
                        }
                    }
                }

                novoPedido.Products = listaDeProdutos;

                await _order.InsertOneAsync(novoPedido);

                return Ok("Cadastrado com sucesso!");
               
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                Order pedidoBuscado = await _order.Find(o => o.Id == id).FirstOrDefaultAsync();

                if(pedidoBuscado == null)
                {
                    return NotFound("Pedido não encintrado");
                }

                await _order.DeleteOneAsync(o => o.Id == id);

                return Ok("Deletado com sucesso");

            }catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] OrderViewModel pedidoAtualizado)
        {
            try
            {
                Order pedidoBuscado = await _order.Find(o => o.Id == id).FirstOrDefaultAsync();

                if (pedidoBuscado == null)
                {
                    return NotFound("Pedido não encintrado");
                }

                if (pedidoAtualizado.Status != null)
                {
                    pedidoBuscado.Status = pedidoAtualizado.Status;
                }

                if(pedidoAtualizado.Date != null)
                {
                    pedidoBuscado.Date = pedidoAtualizado.Date;
                }

                if(pedidoAtualizado.ClientId != null)
                {
                    Client clientBuscado = await _client.Find(c => c.Id == pedidoAtualizado.ClientId).FirstOrDefaultAsync();

                    if(clientBuscado == null) 
                    {
                        return NotFound("Cliente não encontrado");
                    }

                    pedidoBuscado.ClientId = pedidoAtualizado.ClientId;
                    pedidoBuscado.Client = clientBuscado;
                }

                if(pedidoAtualizado.ProductsList != null)
                {
                    List<Product> products = new List<Product>();
                    foreach(string idProduto in pedidoAtualizado.ProductsList)
                    {
                        Product produto = await _product.Find(p => p.Id == idProduto).FirstOrDefaultAsync();

                        if(produto == null)
                        {
                            return NotFound("Erro ao cadastrar produtos");
                        }

                        products.Add(produto);
                    }

                    pedidoBuscado.ProductId = pedidoAtualizado.ProductsList;
                    pedidoBuscado.Products = products;
                }

                var update = Builders<Order>.Update.Set(o => o.Status, pedidoBuscado.Status)
                                                   .Set(o => o.Date, pedidoBuscado.Date)
                                                   .Set(o => o.Products, pedidoBuscado.Products)
                                                   .Set(o => o.ProductId, pedidoBuscado.ProductId)
                                                   .Set(o => o.ClientId, pedidoBuscado.ClientId)
                                                   .Set(o => o.Client, pedidoBuscado.Client);

                var filter = Builders<Order>.Filter.Eq(o => o.Id, id);

                await _order.UpdateOneAsync(filter, update);

                return Ok("Pedido Atualizado");
            }
            catch(Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
