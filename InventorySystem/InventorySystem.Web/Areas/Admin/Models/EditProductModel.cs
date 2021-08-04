using Autofac;
using InventorySystem.Store.Services;
using System.ComponentModel.DataAnnotations;
using InventorySystem.Store.BusinessObjects;

namespace InventorySystem.Web.Areas.Admin.Models
{
    public class EditProductModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        public double? Price { get; set; }

        private readonly IProductService _productService;

        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }

        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public void LoadModelData(int id)
        {
            var product = _productService.GetProduct(id);
            Id = product?.Id;
            Name = product?.Name;
            Price = product?.Price;
        }

        public void Update()
        {
            _productService.UpdateProduct(
                new Product
                {
                    Id = Id.HasValue ? Id.Value : 0,
                    Name = Name,
                    Price = Price.HasValue ? Price.Value : 0
                }
            );
        }
    }
}
