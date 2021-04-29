using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class BitCoinController : Controller
    {
        public IActionResult GetPrice()
        {
            return View(new BitCoinModel());
        }
    }
}
