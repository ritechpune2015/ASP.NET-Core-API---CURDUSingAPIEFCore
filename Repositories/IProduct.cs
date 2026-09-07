using CURDUSingAPIEFCore.Models;

namespace CURDUSingAPIEFCore.Repositories
{
    public interface IProduct
    {
        Task<List<Product>> GetProducts();  
        Task<Product> GetProductById(Int64 id);
        Task<Product> AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Int64 id);
    }
}
