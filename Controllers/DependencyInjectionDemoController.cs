using Microsoft.AspNetCore.Mvc;
using System;
using DotNetNote.Services;

namespace DotNetNote.Controllers
{
    public class DependencyInjectionDemoController : Controller
    {
        private ICopyrightService _svc;
        private ICopyrightService _svc2;

        public DependencyInjectionDemoController(ICopyrightService svc, ICopyrightService svc2)
        {
            _svc = svc;
            _svc2 = svc2;
        }

        public IActionResult Index()
        {
            ViewBag.Copyright = _svc.GetCopyrightString() + ", " + _svc2.GetCopyrightString();

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Copyright = _svc.GetCopyrightString();

            return View();
        }

        public IActionResult AtInjectDemo()
        {
            return View();
        }
    }
}