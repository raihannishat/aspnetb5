using ECommerceSystem.Sales.Repositories;
using ECommerceSystem.Data;

namespace ECommerceSystem.Sales.UnitOfWorks
{
    public interface ISalesUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}