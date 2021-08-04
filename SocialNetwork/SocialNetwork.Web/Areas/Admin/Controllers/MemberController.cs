using System;
using SocialNetwork.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SocialNetwork.Web.Areas.Admin.Models;

namespace SocialNetwork.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new MemberListModel());
        }

        public JsonResult GetMemberData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new MemberListModel();
            var data = model.GetMembers(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateMemberModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateMemberModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create member");
                    _logger.LogError(ex, "Create member Failed");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditMemberModel();
            model.LoadModelData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditMemberModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = new MemberListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
