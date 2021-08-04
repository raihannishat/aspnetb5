using System;

namespace TicketBookingSystem.Data
{
    public abstract class Entity<T>
    {
        public abstract T Id { get; set; }
    }
}
