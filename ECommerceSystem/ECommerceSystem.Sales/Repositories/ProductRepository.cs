using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.Data;
using ECommerceSystem.Sales.Entities;
using ECommerceSystem.Sales.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystem.Sales.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(ISalesDbContext context) : base((Context)context)
        {

        }
    }
}
