using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriversController : Controller
    {
        private readonly IDriverService _driverManager;
        private readonly IEmployeeService _employeeManager;
        public DriversController(IDriverService driverManager, IEmployeeService employeeManager)
        {
            _driverManager = driverManager;
            _employeeManager = employeeManager;
        }
        //GET
        [HttpGet]
        public async Task<IEnumerable<DriverViewModel>> Get()
        {
            var drivers = (await _driverManager.Get()).ToList();
            return drivers;
        }

        [HttpGet("{id}")]
        public async Task<DriverViewModel?> GetById(int id)
        {
            return await _driverManager.Get(id);
        }
        //POST
        [HttpPost]
        public async Task<IActionResult> Post(int employeeId, ICollection<DriverWorkLog>? driverWorkLogs)
        {
            var driver = new DriverViewModel
            {
                EmployeeId = employeeId,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _driverManager.Create(driver);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _driverManager.Delete(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
