using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeManager;
        public EmployeesController(IEmployeeService employeeManager)
        {
            _employeeManager = employeeManager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            var employees = (await _employeeManager.Get())
                .ToList();
            return employees;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeViewModel?> GetEmployeeById(int id)
        {
            var employees = await _employeeManager.Get(id);
            return employees;
        }
        //POST
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _employeeManager.Create(employee);
            if (result != null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            int result = await _employeeManager.Delete(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
