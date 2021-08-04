using System;
using Microsoft.AspNetCore.Mvc;
using AttendanceSystem.Web.Models;
using Microsoft.Extensions.Logging;
using AttendanceSystem.Web.Areas.Admin.Models;

namespace AttendanceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger) => _logger = logger;

        public IActionResult Index()
        {
            return View(new StudentListModel());
        }

        public JsonResult GetStudentData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentListModel();
            var data = model.GetStudents(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateStudentModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Student");
                    _logger.LogError(ex, "Create Student Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditStudentModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditStudentModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new StudentListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
