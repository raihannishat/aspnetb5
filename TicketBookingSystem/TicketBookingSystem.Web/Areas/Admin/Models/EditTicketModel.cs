using Autofac;
using TicketBookingSystem.Booking.Services;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class EditTicketModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        public string Destination { get; set; }
        public int? TicketFee { get; set; }

        private readonly ITickerService _tickerService;

        public EditTicketModel()
        {
            _tickerService = Startup.AutofacContainer.Resolve<ITickerService>();
        }

        public void LoadModelData(int id)
        {
            var ticket = _tickerService.GetTicket(id);
            Id = ticket?.Id;
            CustomerId = ticket?.CustomerId;
            Destination = ticket?.Destination;
            TicketFee = ticket?.TicketFee;
        }

        public void Update()
        {
            _tickerService.UpdateTicket(new Ticket
            {
                Id = Id.HasValue ? Id.Value : 0,
                CustomerId = CustomerId.HasValue ? CustomerId.Value : 0,
                Destination = Destination,
                TicketFee = TicketFee.HasValue ? TicketFee.Value : 0
            });
        }
    }
}
