using Business.Interface;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private readonly IDriverManager _driverManager;
        private readonly IEmployeeManager _employeeManager;
        public DriverController(IDriverManager driverManager, IEmployeeManager employeeManager)
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

            int result = await _driverManager.Create(driver);
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
            int result = await _driverManager.Delete(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
