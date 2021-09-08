﻿using StockData.Scraping.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockData.Scraping.UnitOfWorks;
using AutoMapper;

namespace StockData.Scraping.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IScrapingUnitOfWork _scrapingUnitOfWork;
        private readonly IMapper _mapper;

        public StockPriceService(IScrapingUnitOfWork scrapingUnitOfWork, IMapper mapper)
        {
            _scrapingUnitOfWork = scrapingUnitOfWork;
            _mapper = mapper;
        }

        public void CreateStockPrice(StockPrice stockPrice)
        {
            _scrapingUnitOfWork.StockPriceRepository.Add(
                _mapper.Map<Entities.StockPrice>(stockPrice));

            _scrapingUnitOfWork.Save();
        }
    }
}
