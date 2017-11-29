using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetNote.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentResultDemo()
        {
            return Content("ContentResult 반환값");
        }
    }
}