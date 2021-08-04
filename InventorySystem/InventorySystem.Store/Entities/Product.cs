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
