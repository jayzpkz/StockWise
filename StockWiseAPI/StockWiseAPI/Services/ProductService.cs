using StockWiseAPI.DTOs.Requests;
using StockWiseAPI.DTOs.Responses;
using StockWiseAPI.Models;
using StockWiseAPI.Repositories;

namespace StockWiseAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest request)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                StockQuantity = request.StockQuantity,
                UnitPrice = request.UnitPrice,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _productRepository.AddProductAsync(product);

            return new AddProductResponse
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                StockQuantity = product.StockQuantity,
                UnitPrice = product.UnitPrice,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }
    }
}
