using System;
using System.Linq;
using System.Collections.Generic;
using ECommerceSystem.Sales.UnitOfWorks;
using ECommerceSystem.Sales.BusinessObjects;

namespace ECommerceSystem.Sales.Services
{
    public class ProductService : IProductService
    {
        private readonly ISalesUnitOfWork _salesUnitOfWork;

        public ProductService(ISalesUnitOfWork salesUnitOfWork)
        {
            _salesUnitOfWork = salesUnitOfWork;
        }

        public void CreateProduct(Product product)
        {
            _salesUnitOfWork.ProductRepository.Add(
                new Entities.Product
                {
                    Name = product.Name,
                    Price = product.Price
                }
            );

            _salesUnitOfWork.Save();
        }

        public void DeleteProduct(int productId)
        {
            _salesUnitOfWork.ProductRepository.Remove(productId);
            _salesUnitOfWork.Save();
        }

        public Product GetProduct(int id)
        {
            var product = _salesUnitOfWork.ProductRepository.GetById(id);

            if (product == null) return null;

            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public IList<Product> GetAllProducts()
        {
            var productEntities = _salesUnitOfWork.ProductRepository.GetAll();
            var products = new List<Product>();

            foreach (var entity in productEntities)
            {
                products.Add(
                    new Product
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Price = entity.Price
                    }
                );
            }

            return products;
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var productData = _salesUnitOfWork.ProductRepository.GetDynamic(
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

            var productEntity = _salesUnitOfWork.ProductRepository.GetById(product.Id);

            if (productEntity != null)
            {
                productEntity.Name = product.Name;
                productEntity.Price = product.Price;
                _salesUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Product");
            }
        }
    }
}
