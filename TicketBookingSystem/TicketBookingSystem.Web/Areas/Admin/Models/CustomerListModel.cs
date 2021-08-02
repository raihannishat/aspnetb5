using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using TicketBookingSystem.Booking.Services;
using TicketBookingSystem.Web.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Models
{
    public class CustomerListModel
    {
        private readonly ICustomerService _customerService;

        public CustomerListModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }

        public CustomerListModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public object GetCustomers(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _customerService.GetCustomers(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Name", "Age", "Address", "ID" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Age.ToString(),
                            record.Address.ToString(),
                            record.Id.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
