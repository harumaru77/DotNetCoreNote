using Microsoft.AspNetCore.Mvc;
using DotNetNote.Models;

namespace DotNetNote.Controllers
{
    public class FormValidationDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region "순수 HTML과 자바스크립트를 사용한 유효성 검사"
        public IActionResult Html()
        {
            return View();
        }

        public IActionResult HtmlProcess(string txtName, string txtContent)
        {
            ViewBag.ResultString = $"이름: {txtName}, 내용: {Request.Form["txtContent"]}";

            return View();
        }
        #endregion

        #region "MVC Helper Method를 사용한 유효성 검사"        
        [HttpGet]
        public IActionResult HelperMethod()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HelperMethod(string txtName, string txtContent)
        {
            ViewBag.ResultString = $"이름: {txtName}, 내용: {txtContent}";

            return View();
        }
        #endregion

        #region "강력한 형식의 뷰(Strongly Type View) + Model Binding"
        public IActionResult StronglyTypeView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StronglyTypeView(MaximModel model)
        {
            return View();
        }
        #endregion

        #region "Model Validation + Server Validation"
        public IActionResult ModelValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelValidation(MaximModel model)
        {
            // 직접 유효성 검사
            if(string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "이름을 입력하세요.");
            }

            if(string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("Content", "내용을 입력하세요.");                
            }

            if(!ModelState.IsValid)
            {
                // @Html.ValidationSummary(true)일 때는 아래 에러만 표시
                ModelState.AddModelError("", "모든 에러");
            }

            // 넘어온 모델에 대한 유효성 검사
            if(ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }

        public IActionResult Completed()
        {
            return View();
        }
        #endregion

        #region Client Validation
        [HttpGet]
        public IActionResult ClientValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClientValidation(MaximModel model)
        {
            // 넘어온 Model에 대한 유효성 검사
            if(ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }
        #endregion

        #region Tag Helper를 사용한 유효성 검사
        [HttpGet]
        public IActionResult TagHelperValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TagHelperValidation(MaximModel model)
        {
            // 넘어온 Mode에 대한 유효성 검사
            if(ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }
        #endregion
    }
}