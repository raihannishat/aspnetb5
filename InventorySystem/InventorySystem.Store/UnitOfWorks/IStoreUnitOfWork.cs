using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Store.Repositories;

namespace InventorySystem.Store.UnitOfWorks
{
    public interface IStoreUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IStockRepository StockRepository { get; }
    }
}
