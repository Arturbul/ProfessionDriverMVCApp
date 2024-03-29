using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.Api.WorkLog
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverWorkLogController : Controller
    {
        private readonly IDriverWorkLogManager _manager;
        public DriverWorkLogController(IDriverWorkLogManager manager)
        {
            _manager = manager;
        }

        // GET
        [HttpGet]
        public async Task<ICollection<DriverWorkLog>> GetDriverWorkLogs()
        {
            return await _manager.GetDriverWorkLog();
        }

        [HttpGet("{logId}")]
        public async Task<DriverWorkLog?> GetDriverWorkLogById(Guid logId)
        {
            return await _manager.GetDriverWorkLog(logId);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostDriverWorkLog(int driverId, Guid? driverWorkLogDetailId)
        {
            var workLog = new DriverWorkLog()
            {
                DriverId = driverId,
                DriverWorkLogDetailId = driverWorkLogDetailId
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid result = await _manager.PostDriverWorkLog(workLog);
            if (result == Guid.Empty)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // DELETE
        [HttpDelete("{logId}")]
        public async Task<IActionResult> DeleteDriverWorkLog(Guid logId)
        {
            Guid result = await _manager.DeleteDriverWorkLog(logId);
            if (result == Guid.Empty)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
