﻿using System;
using System.Collections.Generic;
using TicketBookingSystem.Data;

namespace TicketBookingSystem.Booking.Entities
{
    public class Customer : Entity<int>
    {
        public override int Id { get ; set ; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public IList<Ticket> Tickets { get; set; }
    }
}
