using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(object id);
    }
}
