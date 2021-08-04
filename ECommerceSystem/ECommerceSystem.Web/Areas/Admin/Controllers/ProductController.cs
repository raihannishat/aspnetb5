using System;
using Microsoft.AspNetCore.Mvc;
using ECommerceSystem.Web.Models;
using Microsoft.Extensions.Logging;
using ECommerceSystem.Web.Areas.Admin.Models;

namespace ECommerceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel());
        }

        public JsonResult GetProductData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductListModel();
            var data = model.GetProducts(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateProductModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Product");
                    _logger.LogError(ex, "Create Product Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditProductModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new ProductListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
