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

        public async Task<IEnumerable<GetProductResponse>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            List<GetProductResponse> productResponse = new List<GetProductResponse>();
            foreach (var product in products)
            {
                productResponse.Add(new GetProductResponse
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

        public async Task<GetProductResponse?> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null) return null;

            return new GetProductResponse
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                StockQuantity = product.StockQuantity,
                UnitPrice = product.UnitPrice,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }

        public async Task<UpdateProductResponse?> UpdateProductAsync(Guid id, UpdateProductRequest request)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null) return null;

            DateTime now = DateTime.Now;
            product.ProductName = request.ProductName;
            product.StockQuantity = request.StockQuantity;
            product.UnitPrice = request.UnitPrice;
            product.UpdatedAt = now;

            await _productRepository.UpdateProductAsync(product);

            return new UpdateProductResponse
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                StockQuantity = product.StockQuantity,
                UnitPrice = product.UnitPrice,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
