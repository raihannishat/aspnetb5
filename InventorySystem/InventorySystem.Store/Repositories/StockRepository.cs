using InventorySystem.Data;
using InventorySystem.Store.Entities;
using InventorySystem.Store.Contexts;

namespace InventorySystem.Store.Repositories
{
    public class StockRepository : Repository<Stock, int>, IStockRepository
    {
        public StockRepository(IStoreDbContext context) : base((Context)context)
        {

        }
    }
}
