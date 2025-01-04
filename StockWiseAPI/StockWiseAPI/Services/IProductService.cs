using StockWiseAPI.DTOs.Requests;
using StockWiseAPI.DTOs.Responses;
using StockWiseAPI.Models;

namespace StockWiseAPI.Services
{
    public interface IProductService
    {
        Task<AddProductResponse> AddProductAsync(AddProductRequest request);
        Task DeleteProductAsync(Guid id);
        Task<IEnumerable<GetProductResponse>> GetAllProductsAsync();
        Task<GetProductResponse?> GetProductByIdAsync(Guid id);
        Task<UpdateProductResponse?> UpdateProductAsync(Guid id, UpdateProductRequest product);
    }
}
