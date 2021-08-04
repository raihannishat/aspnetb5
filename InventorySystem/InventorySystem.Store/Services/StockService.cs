using System;
using System.Linq;
using System.Collections.Generic;
using InventorySystem.Store.UnitOfWorks;
using InventorySystem.Store.BusinessObjects;

namespace InventorySystem.Store.Services
{
    public class StockService : IStockService
    {
        private readonly IStoreUnitOfWork _storeUnitOfWork;

        public StockService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void CreateStock(Stock stock)
        {
            _storeUnitOfWork.StockRepository.Add(
                new Entities.Stock
                {
                    ProductId = stock.ProductId,
                    Quantity = stock.Quantity
                }
            );

            _storeUnitOfWork.Save();
        }

        public void DeleteStock(int stockId)
        {
            _storeUnitOfWork.StockRepository.Remove(stockId);
            _storeUnitOfWork.Save();
        }

        public IList<Stock> GetAllStocks()
        {
            var stockEtities = _storeUnitOfWork.StockRepository.GetAll();
            var stocks = new List<Stock>();

            foreach (var stock in stockEtities)
            {
                stocks.Add(
                    new Stock
                    {
                        Id = stock.Id, 
                        ProductId = stock.ProductId,
                        Quantity = stock.Quantity
                    }
                );
            }

            return stocks;
        }

        public Stock GetStock(int id)
        {
            var stock = _storeUnitOfWork.StockRepository.GetById(id);

            if (stock == null) return null;

            return new Stock
            {
                Id = stock.Id,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity
            };
        }

        public (IList<Stock> records, int total, int totalDisplay) GetStocks(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var stockData = _storeUnitOfWork.StockRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.ProductId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from stock in stockData.data
                          select new Stock
                          {
                              Id = stock.Id,
                              ProductId = stock.ProductId,
                              Quantity = stock.Quantity
                          }).ToList();

            return (result, stockData.total, stockData.totalDisplay);
        }

        public void UpdateStock(Stock stock)
        {
            if (stock == null) throw new InvalidOperationException("Stock is messing");

            var stockEntity = _storeUnitOfWork.StockRepository.GetById(stock.Id);

            if (stockEntity != null)
            {
                stockEntity.ProductId = stock.ProductId;
                stockEntity.Quantity = stock.Quantity;
                _storeUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Stock");
            }
        }
    }
}
