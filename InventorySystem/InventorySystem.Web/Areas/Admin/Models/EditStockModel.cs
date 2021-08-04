using Autofac;
using InventorySystem.Store.Services;
using InventorySystem.Store.BusinessObjects;

namespace InventorySystem.Web.Areas.Admin.Models
{
    public class EditStockModel
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        private readonly IStockService _stockService;

        public EditStockModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }

        public EditStockModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        public void LoadModelData(int id)
        {
            var stock = _stockService.GetStock(id);
            Id = stock.Id;
            ProductId = stock.ProductId;
            Quantity = stock.Quantity;
        }

        public void Update()
        {
            _stockService.UpdateStock(
                new Stock
                {
                    Id = Id.HasValue ? Id.Value : 0,
                    ProductId = ProductId.HasValue ? ProductId.Value : 0,
                    Quantity = Quantity.HasValue ? Quantity.Value : 0
                }
            );
        }
    }
}
