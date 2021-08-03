using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Store.Entities;
using InventorySystem.Data;
using InventorySystem.Store.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Store.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IStoreDbContext context) : base((Context)context)
        {

        }
    }
}
