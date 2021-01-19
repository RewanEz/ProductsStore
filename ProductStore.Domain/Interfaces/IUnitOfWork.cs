using ProductStore.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        void Commit();
        void Rollback();
    }
}
