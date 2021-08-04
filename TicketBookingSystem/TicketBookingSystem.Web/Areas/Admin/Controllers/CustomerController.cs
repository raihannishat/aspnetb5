using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicketBookingSystem.Web.Models;
using TicketBookingSystem.Web.Areas.Admin.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CustomerListModel());
        }

        public JsonResult GetCustomerData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new CustomerListModel();
            var data = model.GetCustomers(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateCustomerModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create customer");
                    _logger.LogError(ex, "Create customer Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditCustomerModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new CustomerListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
