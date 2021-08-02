using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using TicketBookingSystem.Booking.Services;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class TicketListModel
    {
        private readonly ITickerService _tickerService;

        public TicketListModel()
        {
            _tickerService = Startup.AutofacContainer.Resolve<ITickerService>();
        }

        public TicketListModel(ITickerService tickerService)
        {
            _tickerService = tickerService;
        }

        public object GetTickets(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _tickerService.GetTickets(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "CustomerId", "Destination", "TicketFee" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.CustomerId.ToString(),
                            record.Destination.ToString(),
                            record.TicketFee.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _tickerService.DeleteTicket(id);
        }
    }
}
