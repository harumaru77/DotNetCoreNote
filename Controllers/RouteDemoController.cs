using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    [Route("RouteDemo")]
    public class RouteDemoController
    {
        [Route(""), Route("Index")]
        public string Index()
        {
            return "어트리뷰트 라우팅";
        }
    }
}