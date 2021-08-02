using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.Data;
using ECommerceSystem.Sales.Entities;

namespace ECommerceSystem.Sales.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {

    }
}
