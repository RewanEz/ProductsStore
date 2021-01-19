using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductStore.Domain.Interfaces;
using ProductStore.Domain.Product;

namespace ProductStore.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer("Server=.;Database=ProductDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
            });
            return services;
        }
    }
}
