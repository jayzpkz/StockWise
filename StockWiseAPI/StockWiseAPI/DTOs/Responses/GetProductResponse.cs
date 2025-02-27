﻿namespace StockWiseAPI.DTOs.Responses
{
    public class GetProductResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
