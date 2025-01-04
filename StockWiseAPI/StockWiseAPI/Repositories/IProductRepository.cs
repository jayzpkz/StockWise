using StockWiseAPI.DTOs.Responses;
using StockWiseAPI.Models;

namespace StockWiseAPI.Repositories
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid id);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
    }
}
