using System.Collections.Generic;
using ECommerceSystem.Sales.BusinessObjects;

namespace ECommerceSystem.Sales.Services
{
    public interface IProductService
    {
        IList<Product> GetAllProducts();
        void CreateProduct(Product product);
        (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText);
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
