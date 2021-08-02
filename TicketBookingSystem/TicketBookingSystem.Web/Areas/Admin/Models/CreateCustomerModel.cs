using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Booking.Services;
using TicketBookingSystem.Web;
using Autofac;
using TicketBookingSystem.Booking.BusinessObjects;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class CreateCustomerModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        [Required, Range(3, 100)]
        public int Age { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Address shoul be less than 200 characters")]
        public string Address { get; set; }

        private readonly ICustomerService _customerService;

        public CreateCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }

        public CreateCustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void Create()
        {
            _customerService.CreateCustomer(new Customer
            {
                Name = Name,
                Age = Age,
                Address = Address
            });
        }
    }
}
