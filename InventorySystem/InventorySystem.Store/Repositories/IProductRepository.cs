using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;
using InventorySystem.Store.Entities;

namespace InventorySystem.Store.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {

    }
}
