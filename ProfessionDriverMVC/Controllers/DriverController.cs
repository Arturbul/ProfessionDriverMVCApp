using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers
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
        public async Task<ICollection<Driver>> GetDrivers()
        {
            return await _manager.GetDriver();
        }

        [HttpGet("{id}")]
        public async Task<Driver?> GetDriverById(int id)
        {
            return await _manager.GetDriver(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostDriver(int employeeId)
        {
            var driver = new Driver()
            {
                EmployeeId = employeeId,
                DriverWorkLogs = []
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

        [HttpPost("withlogs")]
        public async Task<IActionResult> PostDriverWithLogs(int employeeId, ICollection<DriverWorkLog> driverWorkLogs)
        {
            var driver = new Driver()
            {
                EmployeeId = employeeId,
                DriverWorkLogs = driverWorkLogs.ToList()
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
        public async Task<IActionResult> DeleteDriver(int id)
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
