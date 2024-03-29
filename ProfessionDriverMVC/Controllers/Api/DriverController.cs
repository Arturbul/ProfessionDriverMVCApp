using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverManager _manager;
        public DriverController(IDriverManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<Driver>> Get()
        {
            return await _manager.GetDriver();
        }

        [HttpGet("{id}")]
        public async Task<Driver?> GetById(int id)
        {
            return await _manager.GetDriver(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Post(int employeeId, ICollection<DriverWorkLog>? driverWorkLogs)
        {
            var driver = new Driver()
            {
                EmployeeId = employeeId,
                DriverWorkLogs = driverWorkLogs
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int result = await _manager.PostDriver(driver);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _manager.DeleteDriver(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
