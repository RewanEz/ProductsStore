using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductStore.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProductDbContext _context;
        public Repository(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }


    }
}
