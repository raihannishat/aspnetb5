using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Data;

namespace InventorySystem.Store.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Stock Stock { get; set; }
    }
}
