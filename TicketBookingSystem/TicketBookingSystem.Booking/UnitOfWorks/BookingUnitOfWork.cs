using TicketBookingSystem.Data;
using TicketBookingSystem.Booking.Contexts;
using TicketBookingSystem.Booking.Repositories;

namespace TicketBookingSystem.Booking.UnitOfWorks
{
    public class BookingUnitOfWork : UnitOfWork, IBookingUnitOfWork
    {
        public BookingUnitOfWork(IBookingDbContext dbContext, ICustomerRepository customerRepository,
            ITicketRepository ticketRepository) : base((Context)dbContext)
        {
            CustomerRepository = customerRepository;
            TicketRepository = ticketRepository;
        }

        public ICustomerRepository CustomerRepository { get; private set; }
        public ITicketRepository TicketRepository { get; private set; }
    }
}
