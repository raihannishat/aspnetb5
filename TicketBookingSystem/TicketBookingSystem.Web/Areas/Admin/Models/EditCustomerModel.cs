using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using TicketBookingSystem.Booking.BusinessObjects;
using TicketBookingSystem.Booking.Services;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class EditCustomerModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        [Required, Range(3, 100)]
        public int? Age { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Address shoul be less than 200 characters")]
        public string Address { get; set; }

        private readonly ICustomerService _customerService;

        public EditCustomerModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }

        public void LoadModelData(int id)
        {
            var customer = _customerService.GetCustomer(id);
            Id = customer?.Id;
            Name = customer?.Name;
            Age = customer?.Age;
            Address = customer?.Address;
        }

        public void Update()
        {
            _customerService.UpdateCustomer(new Customer
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                Age = Age.HasValue ? Age.Value : 0,
                Address = Address
            });
        }
    }
}
