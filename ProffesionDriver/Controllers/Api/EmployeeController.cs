using Business.Interface;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
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

            int result = await _employeeManager.Create(employee);
            if (result == 0)
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
