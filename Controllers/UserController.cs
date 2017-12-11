using DotNetNote.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetNote.Controllers
{
    public class UserController : Controller
    {
        // [User][6][1]
        private IUserRepository _repository;
        private ILogger<UserController> _logger;

        public UserController(IUserRepository repository, ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // [User][6][2]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // [User][6][3]
        // 회원가입 폼
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // [User][6][4]
        // 회원가입 처리 
        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            _logger.LogDebug("[Register]======================================================");
            _logger.LogDebug("UserID : {0}", model.UserId);
            _logger.LogDebug("Password : {0}", model.Password);

            if(ModelState.IsValid)
            {
                if(_repository.GetUserByUserId(model.UserId) != null)
                {
                    ModelState.AddModelError("","이미 가입된 사용자입니다.");                    
                    return View(model);
                }
            }

            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","잘못된 가입 시도!!!");
                return View(model);
            }
            else{
                _logger.LogDebug("가입처리 -> ID : {0}, Password : {1}", model.UserId, model.Password);
                _repository.AddUser(model.UserId, model.Password);
                _logger.LogDebug("전체 사용자 수 : {0}", _repository.GetUserCount());

                return RedirectToAction("Index");
            }
        }

        // [User][6][5]
        // 로그인 폼        
        [HttpGet]
        [AllowAnonymous]    // 인증되지 않은 사용자도 접근 가능
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // [User][6][6]
        // 로그인 처리
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserViewModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                if(_repository.IsCorrectUser(model.UserId, model.Password))
                {
                    // [!] 인증 부여
                    var claims = new List<Claim>()
                    {
                        // 로그인 아이디 지정
                        new Claim("UserId", model.UserId),
                        // 기본 역할 지정, "Role" 기능에 "Users" 값 부여
                        new Claim(ClaimTypes.Role, "Users") // 추가정보 기록
                    };

                    var ci = new ClaimsIdentity(claims, model.Password);

                    await HttpContext.Authentication.SignInAsync("MyCookieAuthenticationScheme", new ClaimsPrincipal(ci));

                    return LocalRedirect("/User/Index");
                }
            }

            return View(model);
        }

        // [User][6][7]
        // 로그아웃 처리
        public async Task<IActionResult> Logout()
        {   
            await HttpContext.Authentication.SignOutAsync("MyCookieAuthenticationScheme");

            return Redirect("/User/Index");
        }

        // [User][6][8]
        // 회원정보 보기 및 수정
        [Authorize]
        public IActionResult UserInfo()
        {
            return View();
        }

        // [User][6][9]
        // 인사말 페이지
        public IActionResult Greeting()
        {
            // [Authorize] 특성의 또 다른 표현 방법
            // 인증되지 않은 사용자는
            if(User.Identity.IsAuthenticated == false)
            {
                // 로그인 페이지로 리다이렉션
                return new ChallengeResult();
            }

            return View();
        }

        // 접근 거부 페이지
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}

