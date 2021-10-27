using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataImporter.Web.Models.Imports;
using Microsoft.Extensions.Logging;
using DataImporter.Core;

namespace DataImporter.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class ImportController : Controller
    {
        private readonly ILogger<ImportController> _logger;

        public ImportController(ILogger<ImportController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ImportListModel());
        }

        public IActionResult ImportHistory()
        {
            return View(new ImportListModel());
        }

        public IActionResult GetImportData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new ImportListModel();
            var data = model.GetImpots(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult UploadExcelFile(int id)
        {
            var model = new CreateImportModel();
            model.GroupId = id;
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadExcelFile(IFormFile file, CreateImportModel model)
        {
            await UploadFile(file, model);
            return RedirectToAction(nameof(ImportHistory));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<bool> UploadFile(IFormFile file, CreateImportModel model)
        {
            string path = null;
            bool copy = false;

            try
            {
                if (file.Length > 0)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Upload"));

                    using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        TempData["msg"] = "File upload successful";
                        model.Location = Path.GetFullPath(path) + "\\" + fileName;
                        model.ImportStatus = "Working";
                        model.ImportDate = DateTime.Now;
                        model.Create();
                    }

                    copy = true;
                }
                else
                {
                    copy = false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Upload error Message: ", ex.Message);
            }

            return copy;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ImportListModel();
            model.Delete(id);

            return RedirectToAction(nameof(ImportHistory));
        }
    }
}
