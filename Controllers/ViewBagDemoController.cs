using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class ViewBagDemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "박성준";
            ViewBag.Age = 21;
            ViewBag.원하는모든단어 = "모든 값...";

            ViewData["Address"] = "세종시...";

            return View();
        }
    }
}