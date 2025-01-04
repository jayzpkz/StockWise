using StockWiseAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StockWiseAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
