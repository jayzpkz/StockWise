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
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, message = "Validation failed", errors });
            }

            var response = await _productService.AddProductAsync(request);
            return Ok(new { success = true, product = response });
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return Ok(new { success = true, products = response });
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            return Ok(new { success = true, product = response });
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { success = false, message = "Validation failed", errors });
            }

            var response = await _productService.UpdateProductAsync(id, request);
            return Ok(new { success = true, product = response });
        }
    }
}
