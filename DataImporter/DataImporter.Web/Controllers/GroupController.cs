using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataImporter.Web.Models.Groups;
using DataImporter.Core;
using System.Security.Claims;

namespace DataImporter.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GroupController(ILogger<GroupController> logger, 
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View(new GroupListModel());
        }

        public IActionResult GetGroupData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new GroupListModel();
            var data = model.GetGroups(dataTablesModel);
            return Json(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateGroupModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateGroupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.ApplicationUserId = Guid.Parse(_httpContextAccessor
                        .HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    model.Create();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create group");
                    _logger.LogError(ex, "Create Group Failed");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditGroupModel();
            model.LoadModelData(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditGroupModel model)
        {
            if (ModelState.IsValid)
            {
                model.ApplicationUserId = Guid.Parse(_httpContextAccessor
                    .HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                model.Update();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new GroupListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
