using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProfessionDriverApp.RazorPages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Swagger()
        {
            return Redirect("/swagger");
        }

    }
}
