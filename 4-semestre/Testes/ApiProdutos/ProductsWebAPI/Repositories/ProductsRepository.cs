using ProductsWebAPI.Context;
using ProductsWebAPI.Domains;
using ProductsWebAPI.Interfaces;

namespace ProductsWebAPI.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _context;
        public ProductsRepository(ProductsContext context)
        {
            _context = context;
        }

        public void Delete(Guid productId)
        {
            Products produtoBuscado = _context.Products.FirstOrDefault(p => p.Id == productId)!;
            _context.Products.Remove(produtoBuscado);
            _context.SaveChanges();
        }

        public List<Products> Get()
        {
            List<Products> produtos = _context.Products.ToList();
            return produtos;
        }

        public Products GetById(Guid productId)
        {
            Products pordutoBuscado = _context.Products.FirstOrDefault(p => p.Id == productId)!;

            if (pordutoBuscado == null)
            {
                return null!;
            }

            return pordutoBuscado;
        }

        public void Post(Products newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void Put(Guid productId, Products updatedProduct)
        {
            Products produtoBuscado = _context.Products.FirstOrDefault(p => p.Id == productId)!;

            produtoBuscado.Name = (updatedProduct.Name != null) ? updatedProduct.Name : produtoBuscado.Name;
            produtoBuscado.Price = (updatedProduct.Price != 0) ? updatedProduct.Price : produtoBuscado.Price;

            _context.Products.Update(produtoBuscado);
            _context.SaveChanges();
        }
    }
}
