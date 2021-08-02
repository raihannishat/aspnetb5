using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingSystem.Data
{
    public abstract class Entity<T>
    {
        public abstract T Id { get; set; }
    }
}
