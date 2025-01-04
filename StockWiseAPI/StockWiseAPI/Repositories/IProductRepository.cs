using StockWiseAPI.Models;

namespace StockWiseAPI.Repositories
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
