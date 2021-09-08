using StockData.Scraping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using StockData.Scraping.BusinessObjects;

namespace StockData.Worker.Models
{
    public class TableModel
    {
        private readonly ICompanyService CompanyService;
        private readonly IStockPriceService StockPriceService;
        private readonly DataModel _dataModel;

        public TableModel()
        {
            CompanyService = Worker.AutofacContainer.Resolve<ICompanyService>();
            StockPriceService = Worker.AutofacContainer.Resolve<IStockPriceService>();
            _dataModel = new DataModel();
        }

        public TableModel(ICompanyService companyService, IStockPriceService stockPriceService)
        {
            CompanyService = companyService;
            StockPriceService = stockPriceService;
            _dataModel = new DataModel();
        }

        public void Save()
        {
            if (_dataModel.CurrentStatus.Equals("Closed"))
            {
                foreach (var item in _dataModel.GetAllData())
                {
                    var company = new Company
                    {
                        Id = item.Id,
                        TradeCode = item.TradingCode
                    };

                    var stockPrice = new StockPrice
                    {
                        CompanyId = company.Id,
                        LastTradingPrice = item.LastTradingPrice,
                        High = item.High,
                        Low = item.Low,
                        ClosePrice = item.ClosePrice,
                        YesterdayClosePrice = item.YesterdayClosePrice,
                        Change = item.Change,
                        Trade = item.Trade,
                        Value = item.Value,
                        Volume = item.Volume,
                    };

                    CompanyService.CreateCompany(company);
                    StockPriceService.CreateStockPrice(stockPrice);
                }
            }
        }
    }
}
