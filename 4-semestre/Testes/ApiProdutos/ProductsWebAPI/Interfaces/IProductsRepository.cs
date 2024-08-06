using ProductsWebAPI.Domains;

namespace ProductsWebAPI.Interfaces
{
    public interface IProductsRepository
    {
        List<Products> Get();
        Products GetById(Guid productId);
        void Post(Products newProduct);
        void Delete(Guid productId);
        void Put(Guid productId, Products updatedProduct);
    }
}
