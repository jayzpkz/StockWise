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
            DateTime now = DateTime.Now;
            var product = new Product
            {
                ProductName = request.ProductName,
                StockQuantity = request.StockQuantity,
                UnitPrice = request.UnitPrice,
                CreatedAt = now,
                UpdatedAt = now
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

        public async Task<IEnumerable<GetProductsResponse>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            List<GetProductsResponse> productResponse = new List<GetProductsResponse>();
            foreach (var product in products)
            {
                productResponse.Add(new GetProductsResponse
                {
                    ProductId= product.Id,
                    ProductName = product.ProductName,
                    StockQuantity = product.StockQuantity,
                    UnitPrice = product.UnitPrice,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt
                });
            }

            return productResponse;
        }
    }
}
