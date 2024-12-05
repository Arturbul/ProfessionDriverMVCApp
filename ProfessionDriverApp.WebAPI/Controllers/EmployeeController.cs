using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetEmployees(string? companyName)
        {
            try
            {
                var result = await _employeeService.GetEmployees(companyName);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User either has no company or unauthorized.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
