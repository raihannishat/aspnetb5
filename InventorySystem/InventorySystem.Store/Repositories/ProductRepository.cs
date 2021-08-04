using InventorySystem.Data;
using InventorySystem.Store.Contexts;
using InventorySystem.Store.Entities;

namespace InventorySystem.Store.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IStoreDbContext context) : base((Context)context)
        {

        }
    }
}
