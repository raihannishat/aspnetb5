using Autofac;
using System.Linq;
using TicketBookingSystem.Web.Models;
using TicketBookingSystem.Booking.Services;

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
                dataTablesModel.GetSortText(new string[] { "Id", "Name", "Age", "Address" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Name,
                            record.Age.ToString(),
                            record.Address.ToString(),
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
