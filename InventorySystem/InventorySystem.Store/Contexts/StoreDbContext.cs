using Microsoft.EntityFrameworkCore;
using InventorySystem.Store.Entities;

namespace InventorySystem.Store.Contexts
{
    public class StoreDbContext : Context, IStoreDbContext
    {
        public StoreDbContext(string connectionString, string migrationAssembly)
            : base(connectionString, migrationAssembly)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(s => s.Stock)
                .WithOne(p => p.Product)
                .HasForeignKey<Stock>(s => s.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
