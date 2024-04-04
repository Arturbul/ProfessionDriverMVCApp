using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriver.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.ViewControllers
{
    public class DriverController : Controller
    {
        private readonly IDriverManager _driverManager;
        private readonly IEmployeeManager _employeeManager;
        public DriverController(IDriverManager driverManager, IEmployeeManager employeeManager)
        {
            _driverManager = driverManager;
            _employeeManager = employeeManager;
        }
        public async Task<IActionResult> Index()
        {
            var drivers = (await _driverManager.Get())
                .Select(d => (DriverViewModel?)d)
                .ToList();

            foreach (var driver in drivers)
            {
                if (driver == null) continue;
                var employee = await _employeeManager.Get(driver.EmployeeId);
                driver.Employee = employee;
            }
            return View(drivers);
        }

        public async Task<IActionResult> Index(int? id)
        {
            var driver = (DriverViewModel?)await _driverManager.Get();
            if (driver == null)
            {
                return NotFound();
            }

            var employee = await _employeeManager.Get(driver.EmployeeId);
            driver.Employee = employee;
            return View(driver);
        }


    }
}
