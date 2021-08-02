using TicketBookingSystem.Data;
using TicketBookingSystem.Booking.Repositories;

namespace TicketBookingSystem.Booking.UnitOfWorks
{
    public interface IBookingUnitOfWork : IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        ITicketRepository TicketRepository { get; }
    }
}
