using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("~/Views/About/Index.cshtml");
        }

        public IActionResult Work()
        {
            return View("~/Views/Work/Index.cshtml");
        }

        public IActionResult Contact()
        {
            return View("~/Views/Contact/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
