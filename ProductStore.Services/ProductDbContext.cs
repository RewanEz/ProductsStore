using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Product;

namespace ProductStore.Services
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Product> Products { get; set; }
    }
}
