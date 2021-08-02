using ECommerceSystem.Sales.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystem.Sales.Contexts
{
    public interface ISalesDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}