using TicketBookingSystem.Data;
using TicketBookingSystem.Booking.Entities;
using TicketBookingSystem.Booking.Contexts;

namespace TicketBookingSystem.Booking.Repositories
{
    public class TicketRepository : Repository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(IBookingDbContext context) : base((Context)context)
        {
            
        }
    }
}
