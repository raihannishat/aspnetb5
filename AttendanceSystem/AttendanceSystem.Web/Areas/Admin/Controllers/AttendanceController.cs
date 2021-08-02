using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Web.Areas.Admin.Models;
using AttendanceSystem.Web.Models;

namespace AttendanceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly ILogger<AttendanceController> _logger;

        public AttendanceController(ILogger<AttendanceController> logger) => _logger = logger;

        public IActionResult Index()
        {
            return View(new AttendanceListModel());
        }

        public JsonResult GetAttendanceData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new AttendanceListModel();
            var data = model.GetAttendance(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateAttendanceModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateAttendanceModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create Attendance");
                    _logger.LogError(ex, "Create Attendance Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditAttendanceModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditAttendanceModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new AttendanceListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
