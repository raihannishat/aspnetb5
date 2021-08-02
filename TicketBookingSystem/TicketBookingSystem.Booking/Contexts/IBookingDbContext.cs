using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Booking.Entities;

namespace TicketBookingSystem.Booking.Contexts
{
    public interface IBookingDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Ticket> Tickets { get; set; }
    }
}