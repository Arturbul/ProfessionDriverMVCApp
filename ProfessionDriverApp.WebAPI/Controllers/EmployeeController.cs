using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Interfaces;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService manager)
        {
            _employeeService = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDTO?> Get(int id)
        {
            var userName = User.Identity?.Name; // Pobieranie nazwy użytkownika
            var a = await _employeeService.Get();
            return null;

        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDTO entity)
        {
            return null;

        }


        //DELETE
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(1);

        }
    }
}
