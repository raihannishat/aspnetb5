using ECommerceSystem.Data;
using ECommerceSystem.Sales.Contexts;
using ECommerceSystem.Sales.Repositories;

namespace ECommerceSystem.Sales.UnitOfWorks
{
    public class SalesUnitOfWork : UnitOfWork, ISalesUnitOfWork
    {
        public SalesUnitOfWork(ISalesDbContext dbContext, IProductRepository productRepository) 
            : base((Context)dbContext)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; private set; }
    }
}
