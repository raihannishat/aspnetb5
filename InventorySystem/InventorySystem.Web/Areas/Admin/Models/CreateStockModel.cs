using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySystem.Store.BusinessObjects;
using InventorySystem.Store.Services;
using Autofac;

namespace InventorySystem.Web.Areas.Admin.Models
{
    public class CreateStockModel
    {
        private readonly IStockService _stockService;

        public CreateStockModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }

        public CreateStockModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Create()
        {
            _stockService.CreateStock(
                new Stock
                {
                    ProductId = ProductId,
                    Quantity = Quantity
                }
            );
        }
    }
}
