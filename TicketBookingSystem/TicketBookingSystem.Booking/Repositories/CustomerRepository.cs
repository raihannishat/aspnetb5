using TicketBookingSystem.Data;
using TicketBookingSystem.Booking.Entities;
using TicketBookingSystem.Booking.Contexts;

namespace TicketBookingSystem.Booking.Repositories
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IBookingDbContext context) : base((Context)context)
        {
            
        }
    }
}
