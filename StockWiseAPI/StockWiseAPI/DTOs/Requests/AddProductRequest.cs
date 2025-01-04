using System.ComponentModel.DataAnnotations;

namespace StockWiseAPI.DTOs.Requests
{
    public class AddProductRequest
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be a positive number greater than zero.")]
        public decimal UnitPrice { get; set; }
    }
}
