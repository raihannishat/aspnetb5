using ECommerceSystem.Data;
using ECommerceSystem.Sales.Repositories;

namespace ECommerceSystem.Sales.UnitOfWorks
{
    public interface ISalesUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}