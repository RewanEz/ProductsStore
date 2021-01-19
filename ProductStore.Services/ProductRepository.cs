using ProductStore.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Services
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {

        }
    }
}
