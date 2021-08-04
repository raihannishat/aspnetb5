using Autofac;
using ECommerceSystem.Sales.Services;
using ECommerceSystem.Sales.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class CreateProductModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        public int Price { get; set; }

        private readonly IProductService  _productService;

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }

        public void Create()
        {
            _productService.CreateProduct(
                new Product
                {
                    Name = Name,
                    Price = Price
                }
            );
        }
    }
}
