using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;

namespace ProfessionDriverApp.RazorPages.Controllers
{
    public class DriverWorkLogsController : Controller
    {
        private readonly IDriverWorkLogService _driverWorkLogManager;
        public DriverWorkLogsController(IDriverWorkLogService driverWorkLogManager)
        {
            _driverWorkLogManager = driverWorkLogManager;
        }
        public async Task<IActionResult> Index()
        {
            var logs = await _driverWorkLogManager.Get();
            return View(logs.ToList());
        }
    }
}
