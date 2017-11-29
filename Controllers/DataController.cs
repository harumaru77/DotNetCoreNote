using DotNetNote.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            DataService demoService = new DataService();
            var data = demoService.GetAll();

            return View(data);
        }
    }
}