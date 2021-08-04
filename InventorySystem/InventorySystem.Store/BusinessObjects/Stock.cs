using System;

namespace InventorySystem.Store.BusinessObjects
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
