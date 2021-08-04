using Autofac;
using System.Linq;
using ECommerceSystem.Web.Models;
using ECommerceSystem.Sales.Services;

namespace ECommerceSystem.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private readonly IProductService _productService;

        public ProductListModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public ProductListModel(IProductService productService)
        {
            _productService = productService;
        }

        public object GetProducts(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _productService.GetProducts(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Name", "Price", "Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Price.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }
            
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
