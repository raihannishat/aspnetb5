using InventorySystem.Data;

namespace InventorySystem.Store.Entities
{
    public class Stock : IEntity<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
