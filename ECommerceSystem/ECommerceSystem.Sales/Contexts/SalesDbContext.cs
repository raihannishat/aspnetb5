using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
