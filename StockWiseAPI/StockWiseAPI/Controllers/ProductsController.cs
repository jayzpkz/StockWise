using Microsoft.AspNetCore.Mvc;
using StockWiseAPI.DTOs.Requests;
using StockWiseAPI.DTOs.Responses;
using StockWiseAPI.Services;

namespace StockWiseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return all validation errors
            }

            var response = await _productService.AddProductAsync(request);
            return Ok(response);
        }

        [Route("get")]
        [HttpGet]
        public async Task<IEnumerable<GetProductResponse>> GetAllProducts()
        {
            return await _productService.GetAllProductsAsync();
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<GetProductResponse?> GetProductById(Guid id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _productService.UpdateProductAsync(id, request);
            return Ok(response);
        }
    }
}
