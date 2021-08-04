using Microsoft.EntityFrameworkCore;
using ECommerceSystem.Sales.Entities;

namespace ECommerceSystem.Sales.Contexts
{
    public class SalesDbContext : Context, ISalesDbContext
    {
        public SalesDbContext(string connectionString, string migrationAssembly) 
            : base(connectionString, migrationAssembly)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
