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

            // here i`ll add function that will send this data to sql server.
            var response = await _productService.AddProductAsync(request);
            return Ok(response);
        }
    }
}
