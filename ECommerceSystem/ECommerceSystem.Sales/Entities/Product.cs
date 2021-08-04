using ECommerceSystem.Data;

namespace ECommerceSystem.Sales.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public int Price { get; set; }
    }
}
