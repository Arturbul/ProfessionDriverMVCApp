using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/driver-work-logs")]
    public class DriverWorkLogsController : Controller
    {
        private readonly IDriverWorkLogService _manager;
        public DriverWorkLogsController(IDriverWorkLogService manager)
        {
            _manager = manager;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<DriverWorkLogViewModel>> GetDriverWorkLogs()
        {
            return await _manager.Get();
        }

        /*[HttpGet("{logId}")]
        public async Task<DriverWorkLogViewModel?> GetDriverWorkLogById(Guid logId)
        {
            return await _manager.Get(logId);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostDriverWorkLog(int driverId, Guid? driverWorkLogDetailId)
        {
            var workLog = new DriverWorkLog()
            {
                DriverId = driverId,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(workLog);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        // DELETE
        [HttpDelete("{logId}")]
        public async Task<IActionResult> DeleteDriverWorkLog(Guid logId)
        {
            var result = await _manager.Delete(logId);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }*/
    }
}
