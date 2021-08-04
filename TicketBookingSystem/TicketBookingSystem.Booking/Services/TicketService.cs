using System;
using System.Linq;
using System.Collections.Generic;
using TicketBookingSystem.Booking.UnitOfWorks;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Booking.Services
{
    public class TicketService : ITickerService
    {
        private readonly IBookingUnitOfWork _bookingUnitOfWork;

        public TicketService(IBookingUnitOfWork bookingUnitOfWork)
        {
            _bookingUnitOfWork = bookingUnitOfWork;
        }

        public IList<Ticket> GetAllTickets()
        {
            var ticketEntities = _bookingUnitOfWork.TicketRepository.GetAll();
            var tickets = new List<Ticket>();

            foreach (var entity in ticketEntities)
            {
                tickets.Add(new Ticket
                {
                    Id = entity.Id,
                    CustomerId = entity.CustomerId,
                    Destination = entity.Destination,
                    TicketFee = entity.TicketFee
                });
            }

            return tickets;
        }

        public void CreateTicket(Ticket ticket)
        {
            _bookingUnitOfWork.TicketRepository.Add(
                new Entities.Ticket
                {
                    CustomerId = ticket.CustomerId,
                    Destination = ticket.Destination,
                    TicketFee = ticket.TicketFee
                }
            );

            _bookingUnitOfWork.Save();
        }

        public (IList<Ticket> records, int total, int totalDisplay) GetTickets(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var ticketData = _bookingUnitOfWork.TicketRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.CustomerId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from ticket in ticketData.data
                          select new Ticket
                          {
                              Id = ticket.Id,
                              CustomerId = ticket.CustomerId,
                              Destination = ticket.Destination,
                              TicketFee = ticket.TicketFee
                          }).ToList();

            return (result, ticketData.total, ticketData.totalDisplay);
        }

        public Ticket GetTicket(int id)
        {
            var ticket = _bookingUnitOfWork.TicketRepository.GetById(id);

            if (ticket == null) return null;

            return new Ticket
            {
                Id = ticket.Id,
                CustomerId = ticket.CustomerId,
                Destination = ticket.Destination,
                TicketFee = ticket.TicketFee
            };
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new InvalidOperationException("Ticket is messing");
            }

            var ticketEntity = _bookingUnitOfWork.TicketRepository.GetById(ticket.Id);

            if (ticketEntity != null)
            {
                ticketEntity.CustomerId = ticket.CustomerId;
                ticketEntity.Destination = ticket.Destination;
                ticketEntity.TicketFee = ticket.TicketFee;
                _bookingUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find ticket");
            }
        }

        public void DeleteTicket(int id)
        {
            _bookingUnitOfWork.TicketRepository.Remove(id);
            _bookingUnitOfWork.Save();
        }
    }
}
