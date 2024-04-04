using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriver.ViewModels;
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
        public async Task<IEnumerable<DriverViewModel?>> Get()
        {
            var drivers = (await _driverManager.Get())
               .Select(d => (DriverViewModel?)d)
               .ToList();

            foreach (var driver in drivers)
            {
                if (driver == null) continue;
                var employee = await _employeeManager.Get(driver.EmployeeId);
                driver.Employee = employee;
            }
            return drivers;
        }

        /*   [HttpGet("{id}")]
           public async Task<Driver?> GetById(int id)
           {
               return await _manager.Get(id);
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

               int result = await _manager.Create(driver);
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
               int result = await _manager.Delete(id);
               if (result == 0)
               {
                   return NotFound(result);
               }
               return Ok(result);
           }*/
    }
}
