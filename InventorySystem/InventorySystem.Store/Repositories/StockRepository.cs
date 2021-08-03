using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Store.Entities;
using InventorySystem.Store.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Store.Repositories
{
    public class StockRepository : Repository<Stock, int>, IStockRepository
    {
        public StockRepository(IStoreDbContext context) : base((Context)context)
        {

        }
    }
}
