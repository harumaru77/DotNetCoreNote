using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DotNetNote.Controllers
{
    public class LoggingDemoController : Controller
    {
        private ILogger<LoggingDemoController> _logger;

        public LoggingDemoController(ILogger<LoggingDemoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index Value {time}", DateTime.Now);

            return View();
        }

        public IActionResult About()
        {
            _logger.LogInformation("About View {time}", DateTime.Now);

            return View();
        }
    }
}