using Microsoft.EntityFrameworkCore;
using InventorySystem.Store.Entities;

namespace InventorySystem.Store.Contexts
{
    public interface IStoreDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Stock> Stocks { get; set; }
    }
}