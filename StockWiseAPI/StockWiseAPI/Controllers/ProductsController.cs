using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(new { success = false, message = "Validation failed", errors });
                }

                var response = await _productService.AddProductAsync(request);
                return Ok(new { success = true, product = response });
            }
            catch (Exception ex)
            {
                // Log the error (you can use a logging framework here)
                _logger.LogError(ex, "An error occurred while adding a product. Request: {@Request}", request);
                return StatusCode(500, new { success = false, message = "An unexpected error occurred", error = ex.Message });
            }
        }

        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = await _productService.GetAllProductsAsync();
                return Ok(new { success = true, products = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the products.");
                return StatusCode(500, new { success = false, message = "An unexpected error occurred", error = ex.Message });
            }
        }

        [Route("get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var response = await _productService.GetProductByIdAsync(id);
                return Ok(new { success = true, product = response });
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex, "An error occurred while getting the product with id {id}.", id);
                return StatusCode(500, new { success = false, message = "An unexpected error occurred", error = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(new { success = false, message = "Validation failed", errors });
                }

                var response = await _productService.UpdateProductAsync(id, request);
                return Ok(new { success = true, product = response });
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex, "An error occurred while updating the product. Request: {@Request}", request);
                return StatusCode(500, new { success = false, message = "An unexpected error occurred", error = ex.Message });
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);

                if (product == null)
                {
                    return NotFound(new { success = false, error = "Product was not found" });
                }

                await _productService.DeleteProductAsync(id);
                return NoContent();  // Return 204 No Content when the deletion is successful.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting product with id {id}.", id);
                return StatusCode(500, new { success = false, error = "An unexpected error occurred" });
            }
        }
    }
}
