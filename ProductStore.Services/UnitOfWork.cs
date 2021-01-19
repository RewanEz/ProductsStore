using ProductStore.Domain.Interfaces;
using ProductStore.Domain.Product;

namespace ProductStore.Services
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductDbContext _context;
        private IProductRepository _productRepository;

        public UnitOfWork(ProductDbContext dbContext)
        {
            _context = dbContext;
        }
        public IProductRepository ProductRepository
        {
            get { return _productRepository ??= new ProductRepository(_context); }
        }

        public void Commit() => _context.SaveChanges();

        public void Rollback() => _context.Dispose();
    }
}
