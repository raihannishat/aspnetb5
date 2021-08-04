using System;
using System.Linq;
using System.Collections.Generic;
using TicketBookingSystem.Booking.UnitOfWorks;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Booking.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IBookingUnitOfWork _bookingUnitOfWork;

        public CustomerService(IBookingUnitOfWork bookingUnitOfWork)
        {
            _bookingUnitOfWork = bookingUnitOfWork;
        }

        public IList<Customer> GetAllCustomers()
        {
            var customerEntities = _bookingUnitOfWork.CustomerRepository.GetAll();
            var customers = new List<Customer>();

            foreach (var entity in customerEntities)
            {
                customers.Add(new Customer
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Age = entity.Age,
                    Address = entity.Address
                });
            }

            return customers;
        }

        public void CreateCustomer(Customer customer)
        {
            _bookingUnitOfWork.CustomerRepository.Add(
                new Entities.Customer
                {
                    Name = customer.Name,
                    Age = customer.Age,
                    Address = customer.Address
                }
            );

            _bookingUnitOfWork.Save();
        }

        public (IList<Customer> records, int total, int totalDisplay) GetCustomers(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var customerData = _bookingUnitOfWork.CustomerRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from customer in customerData.data
                          select new Customer
                          {
                              Id = customer.Id,
                              Name = customer.Name,
                              Age = customer.Age,
                              Address = customer.Address
                          }).ToList();

            return (result, customerData.total, customerData.totalDisplay);
        }

        public Customer GetCustomer(int id)
        {
            var customer = _bookingUnitOfWork.CustomerRepository.GetById(id);

            if (customer == null) return null;

            return new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Address = customer.Address
            };
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidOperationException("Customer is messing");
            }

            var customerEntity = _bookingUnitOfWork.CustomerRepository.GetById(customer.Id);

            if (customerEntity != null)
            {
                customerEntity.Name = customer.Name;
                customerEntity.Age = customer.Age;
                customerEntity.Address = customer.Address;
                _bookingUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find customer");
            }
        }

        public void DeleteCustomer(int customerId)
        {
            _bookingUnitOfWork.CustomerRepository.Remove(customerId);
            _bookingUnitOfWork.Save();
        }
    }
}
