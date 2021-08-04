using InventorySystem.Data;
using InventorySystem.Store.Contexts;
using InventorySystem.Store.Repositories;

namespace InventorySystem.Store.UnitOfWorks
{
    public class StoreUnitOfWork : UnitOfWork, IStoreUnitOfWork
    {
        public StoreUnitOfWork(IStoreDbContext dbContext, 
            IProductRepository productRepository,
            IStockRepository stockRepository) : base((Context)dbContext)
        {
            ProductRepository = productRepository;
            StockRepository = stockRepository;  
        }

        public IProductRepository ProductRepository { get; private set; }
        public IStockRepository StockRepository { get; private set; }
    }
}
