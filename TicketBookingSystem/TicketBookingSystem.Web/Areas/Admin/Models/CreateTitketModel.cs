using Autofac;
using TicketBookingSystem.Booking.Services;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class CreateTitketModel
    {
        public int CustomerId { get; set; }
        public string Destination { get; set; }
        public int TicketFee { get; set; }

        private readonly ITickerService _tickerService;

        public CreateTitketModel()
        {
            _tickerService = Startup.AutofacContainer.Resolve<ITickerService>();
        }

        public CreateTitketModel(ITickerService tickerService)
        {
            _tickerService = tickerService;
        }

        public void Create()
        {
            _tickerService.CreateTicket(new Ticket
            {
                CustomerId = CustomerId,
                Destination = Destination,
                TicketFee = TicketFee
            });
        }

        public void Delete(int id)
        {
            _tickerService.DeleteTicket(id);
        }
    }
}
