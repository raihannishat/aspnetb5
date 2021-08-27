using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Web.Areas.Admin.Models;
using LibraryManagementSystem.Web.Models;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new AuthorListModel());
        }

        public IActionResult GetAuthorData()
        {
            return Json(new AuthorListModel().GetAuthors(new DataTablesAjaxRequestModel(Request)));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateAuthorModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateAuthorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Author");
                    _logger.LogError(ex, "Create Author Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditAuthorModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditAuthorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new AuthorListModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
