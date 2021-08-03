using InventorySystem.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Store.Contexts
{
    public interface IStoreDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Stock> Stocks { get; set; }
    }
}