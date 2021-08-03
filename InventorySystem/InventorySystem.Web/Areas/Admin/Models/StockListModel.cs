using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySystem.Store.Services;
using InventorySystem.Web.Models;

namespace InventorySystem.Web.Areas.Admin.Models
{
    public class StockListModel
    {
        private readonly IStockService _stockService;

        public StockListModel()
        {
            _stockService = Startup.AutofacContainer.Resolve<IStockService>();
        }

        public StockListModel(IStockService stockService)
        {
            _stockService = stockService;
        }

        public object GetStocks(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _stockService.GetStocks(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Id", "ProducId", "Quantity" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.ProductId.ToString(),
                            record.Quantity.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _stockService.DeleteStock(id);
        }
    }
}
