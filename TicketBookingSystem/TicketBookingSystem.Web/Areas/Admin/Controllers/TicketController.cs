using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicketBookingSystem.Web.Models;
using TicketBookingSystem.Web.Areas.Admin.Models;

namespace TicketBookingSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new TicketListModel());
        }

        public JsonResult GetTicketData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new TicketListModel();
            var data = model.GetTickets(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTitketModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateTitketModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create ticket");
                    _logger.LogError(ex, "Create ticket Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditTicketModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditTicketModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new TicketListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
