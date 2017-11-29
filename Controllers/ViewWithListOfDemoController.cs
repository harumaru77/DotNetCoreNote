using Microsoft.AspNetCore.Mvc;
using DotNetNote.Models;
using System.Collections.Generic;

namespace DotNetNote.Controllers
{
    public class ViewWithListOfDemoController : Controller
    {
        public IActionResult Index()
        {
            List<DemoModel> models = new List<DemoModel>(){
                new DemoModel { Id = 1, Name = "홍길동" },
                new DemoModel { Id = 2, Name = "백두산" },
                new DemoModel { Id = 3, Name = "임꺽정" },
            };

            return View(models);
        }
    }
}