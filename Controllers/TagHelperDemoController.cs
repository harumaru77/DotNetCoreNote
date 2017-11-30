using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class TagHelperDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// environment Tag Helper 사용하기
        public IActionResult EnvironmentDemo()
        {
            return View();
        }

        /// 내장 Tag Helper에 접두사 붙이기
        public IActionResult PrefixDemo()
        {
            return View();
        }

        /// <summary>
        /// 사용자 정의 Tag Helper 테스트
        /// 1.일반적으로 프로젝트 루트에 TagHelpers 폴더를 생성하고 이곳에 관련 코드를 만든다.
        /// </summary>
        public IActionResult MyTagHelperDemo()
        {
            return View();
        }

        /// 커스텀(사용자 정의) Tag Helper
        public IActionResult EmailLinkDemo()
        {
            return View();            
        }

        /// 유닉스 시간 변경기 Tag Helper 사용 테스트
        public IActionResult TagHelperDemo()
        {
            return View();
        }

        /// 페이징 Helper
        public IActionResult PagingHelperDemo()
        {
            return View();
        }

        /// Cache Tag Helper
        public IActionResult CacheDemo()
        {
            return View();
        }
    }
}