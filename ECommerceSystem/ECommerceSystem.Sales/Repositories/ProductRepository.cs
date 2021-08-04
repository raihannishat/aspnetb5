using ECommerceSystem.Data;
using ECommerceSystem.Sales.Entities;
using ECommerceSystem.Sales.Contexts;

namespace ECommerceSystem.Sales.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ISalesDbContext context) : base((Context)context)
        {

        }
    }
}
