using Microsoft.AspNetCore.Mvc;
using DotNetNote.Models;

namespace DotNetNote.Controllers
{
    public class ViewWithModelDemoController : Controller
    {
        public IActionResult Index()
        {
            DemoModel dm = new DemoModel();

            dm.Id = 1;
            dm.Name = "홍길동";

            return View(dm);
        }
    }
}