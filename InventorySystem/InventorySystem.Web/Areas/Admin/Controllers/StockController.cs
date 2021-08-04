using System;
using Microsoft.AspNetCore.Mvc;
using InventorySystem.Web.Models;
using Microsoft.Extensions.Logging;
using InventorySystem.Web.Areas.Admin.Models;

namespace InventorySystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new StockListModel());
        }

        public JsonResult GetStockData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new StockListModel();
            var data = model.GetStocks(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateStockModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateStockModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Stock");
                    _logger.LogError(ex, "Create Stock Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditStockModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditStockModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new StockListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
