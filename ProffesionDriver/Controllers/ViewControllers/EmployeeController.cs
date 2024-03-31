using Business.Interface;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriver.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.ViewControllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IEntityManager _entityManager;
        public EmployeeController(IEmployeeManager employeeManager, IEntityManager entityManager)
        {
            _employeeManager = employeeManager;
            _entityManager = entityManager;
        }

        public async Task<IActionResult> Index()
        {
            var employees = (await _employeeManager.Get())
                .Select(e => (EmployeeViewModel?)e)
                .ToList();

            foreach (var employee in employees)
            {
                if (employee == null) continue;
                employee.Entity = await _entityManager.Get(employee.EntityId);
            }
            return View(employees);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = (EmployeeViewModel?)await _employeeManager.Get((int)id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.Entity = await _entityManager.Get(employee.EntityId);
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = (EmployeeViewModel?)await _employeeManager.Get((int)id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.Entity = await _entityManager.Get(employee.EntityId);
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
                var employeeDTO = (EmployeeDTO?)employee;
                if (employeeDTO != null)
                {
                    var result = await _employeeManager.Update(employeeDTO);
                    return RedirectToAction(nameof(Index));
                }
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
                var employeeDTO = (EmployeeDTO?)employee;
                if (employeeDTO != null)
                {
                    var result = await _employeeManager.Create(employeeDTO);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound(id);
            }
            var employee = (EmployeeViewModel?)await _employeeManager.Get((int)id);
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
