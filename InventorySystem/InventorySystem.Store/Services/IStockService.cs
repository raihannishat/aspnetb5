using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.Store.BusinessObjects;

namespace InventorySystem.Store.Services
{
    public interface IStockService
    {
        IList<Stock> GetAllStocks();
        void CreateStock(Stock stock);
        (IList<Stock> records, int total, int totalDisplay) GetStocks(int pageIndex, int pageSize, string searchText, string sortText);
        Stock GetStock(int id);
        void UpdateStock(Stock stock);
        void DeleteStock(int stockId);
    }
}
