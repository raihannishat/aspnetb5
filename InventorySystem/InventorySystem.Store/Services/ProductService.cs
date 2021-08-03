using InventorySystem.Store.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Store.UnitOfWorks;

namespace InventorySystem.Store.Services
{
    public class ProductService : IProductService
    {
        private readonly IStoreUnitOfWork _storeUnitOfWork;

        public ProductService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void CreateProduct(Product product)
        {
            _storeUnitOfWork.ProductRepository.Add(
                new Entities.Product
                {
                    Name = product.Name,
                    Price = product.Price
                }
            );

            _storeUnitOfWork.Save();
        }

        public void DeleteProduct(int productId)
        {
            _storeUnitOfWork.ProductRepository.Remove(productId);
            _storeUnitOfWork.Save();    
        }

        public IList<Product> GetAllProducts()
        {
            var productEntities = _storeUnitOfWork.ProductRepository.GetAll();
            var products = new List<Product>();

            foreach (var product in productEntities)
            {
                products.Add(
                    new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price
                    }
                );
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            var product = _storeUnitOfWork.ProductRepository.GetById(id);

            if (product == null) return null;

            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var productData = _storeUnitOfWork.ProductRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from product in productData.data
                          select new Product
                          {
                              Id = product.Id,
                              Name = product.Name,
                              Price = product.Price
                          }).ToList();

            return (result, productData.total, productData.totalDisplay);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null) throw new InvalidOperationException("Product is messing");

            var productEntity = _storeUnitOfWork.ProductRepository.GetById(product.Id);

            if (productEntity != null)
            {
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                _storeUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Product");
            }
        }
    }
}
