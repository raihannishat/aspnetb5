using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Booking.Entities;

namespace TicketBookingSystem.Booking.Contexts
{
    public class BookingDbContext : Context, IBookingDbContext
    {
        public BookingDbContext(string connectionString, string migrationAssembly) 
            : base(connectionString, migrationAssembly)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(t => t.Tickets)
                .WithOne(c => c.Customer);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
