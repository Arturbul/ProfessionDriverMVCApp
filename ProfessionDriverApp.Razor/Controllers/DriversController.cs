using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.RazorPages.Controllers
{
    public class DriversController : Controller
    {
        private readonly IDriverService _driverManager;
        private readonly IEmployeeService _employeeManager;
        public DriversController(IDriverService driverManager, IEmployeeService employeeManager)
        {
            _driverManager = driverManager;
            _employeeManager = employeeManager;

        }
        public async Task<IActionResult> Index()
        {
            var drivers = (await _driverManager.Get()).ToList();
            return View(drivers);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var driver = await _driverManager.Get((int)id);
            return View(driver);
        }
        public async Task<IActionResult> Add()
        {
            var employeesViewModel = await _employeeManager.Get();
            ViewData["EmployeeId"] = employeesViewModel.Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = e.EmployeeId.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([Bind("EmployeeId")] DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _driverManager.Create(driverViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(driverViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _driverManager.Get((int)id);
            var employeesViewModel = await _employeeManager.Get();
            if (driver == null)
            {
                return NotFound();
            }

            ViewData["EmployeeId"] = employeesViewModel.Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = e.EmployeeId.ToString()
            });
            return View(driver);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DriverViewModel driverViewModel)
        {
            if (id != driverViewModel.DriverId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var result = await _driverManager.Update(driverViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(driverViewModel);
        }
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound(id);
            }
            var employee = await _driverManager.Get((int)id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var employee = await _driverManager.Get(id);
            int result;
            if (employee != null)
            {
                result = await _driverManager.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
