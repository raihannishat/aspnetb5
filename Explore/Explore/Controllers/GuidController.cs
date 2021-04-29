using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore.Models;

namespace Explore.Controllers
{
    public class GuidController : Controller
    {
        public IActionResult GetGuid()
        {
            return View(new GuidModel());
        }
    }
}
