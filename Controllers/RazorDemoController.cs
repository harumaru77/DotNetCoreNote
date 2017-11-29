using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetNote.Controllers
{
    public class RazorDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Demo1()
        {
            return View();
        }

        public IActionResult Demo2()
        {
            return View();
        }
    }
}