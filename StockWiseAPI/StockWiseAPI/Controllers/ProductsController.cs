using Microsoft.AspNetCore.Mvc;
using StockWiseAPI.DTOs.Requests;
using StockWiseAPI.DTOs.Responses;

namespace StockWiseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [Route("add")]
        [HttpPost]
        public IActionResult AddProduct([FromBody] AddProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return all validation errors
            }

            // here i`ll add function that will send this data to sql server.

            return Ok(new AddProductResponse
            {
                ProductId = "123456",
                ProductName = request.ProductName,
                StockQuantity = request.StockQuantity,
                UnitPrice = request.UnitPrice,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
        }
    }
}
