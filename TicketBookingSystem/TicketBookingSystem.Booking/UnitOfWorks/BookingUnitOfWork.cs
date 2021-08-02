using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketBookingSystem.Booking.Contexts;
using TicketBookingSystem.Booking.Repositories;
using TicketBookingSystem.Data;

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
