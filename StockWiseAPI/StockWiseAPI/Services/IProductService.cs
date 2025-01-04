using StockWiseAPI.DTOs.Requests;
using StockWiseAPI.DTOs.Responses;

namespace StockWiseAPI.Services
{
    public interface IProductService
    {
        Task<AddProductResponse> AddProductAsync(AddProductRequest request);
    }
}
