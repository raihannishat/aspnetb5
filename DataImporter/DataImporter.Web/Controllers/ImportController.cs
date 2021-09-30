using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
