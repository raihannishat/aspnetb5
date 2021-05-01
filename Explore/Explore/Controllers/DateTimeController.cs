using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Explore.Models;

namespace Explore.Controllers
{
    public class DateTimeController : Controller
    {
        public IActionResult GetDateTime()
        {
            return View(new DateTimeModel());
        }
    }
}
