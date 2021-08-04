using Autofac;
using System.Linq;
using TicketBookingSystem.Web.Models;
using TicketBookingSystem.Booking.Services;

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
                dataTablesModel.GetSortText(new string[] { "Id", "CustomerId", "Destination", "TicketFee" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
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
