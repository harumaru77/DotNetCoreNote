using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class FormPostDemoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string content)
        {
            ViewBag.Result = $"이름: {name}, 내용: {content}";

            return View();
        }
    }
}