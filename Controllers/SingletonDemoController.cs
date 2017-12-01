using Microsoft.AspNetCore.Mvc;

namespace DotNetNore.Controllers
{
    public class SingletonDemoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Url"] = "www.gilbut.co.kr";
            
            return View();
        }
    }
}