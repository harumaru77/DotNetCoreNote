using Microsoft.AspNetCore.Mvc;
using System;

namespace DotNetNote.Controllers
{
    public class ControllerDemoController : Controller
    {
        public void Index()
        {
            // 아무런 값도 출력하지 않음
        }

        public string StringAction()
        {
            return "String을 반환하는 액션 메서드";
        }

        public DateTime DateTimeAction()
        {
            return DateTime.Now;
        }

        public IActionResult DefaultAction()
        {
            return View();  // 컨트롤러/액션 메서드
        }
    }
}