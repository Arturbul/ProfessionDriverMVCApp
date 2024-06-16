using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.RazorPages.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeManager;
        public EmployeesController(IEmployeeService employeeManager)
        {
            _employeeManager = employeeManager;
        }

        public async Task<IActionResult> Index()
        {
            var employees = _employeeManager.Get();
            return View(await employees.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeManager.Get((int)id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeManager.Get((int)id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId, HireDate, TerminationDate, EntityId")] EmployeeViewModel employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var result = await _employeeManager.Update(employee);
                return RedirectToAction(nameof(Details), result.EmployeeId);
            }
            return View(employee);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([Bind("HireDate, TerminationDate, EntityId")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeManager.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound(id);
            }
            var employee = await _employeeManager.Get((int)id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var employee = await _employeeManager.Get(id);
            int result;
            if (employee != null)
            {
                result = await _employeeManager.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
