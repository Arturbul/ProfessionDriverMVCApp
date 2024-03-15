using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers.WorkLog
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverWorkLogEntryController : Controller
    {
        private readonly IDriverWorkLogEntryManager _manager;
        public DriverWorkLogEntryController(IDriverWorkLogEntryManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<DriverWorkLogEntry>> GetDriverWorkLogEntrys()
        {
            return await _manager.GetDriverWorkLogEntry();
        }

        [HttpGet("{id}")]
        public async Task<DriverWorkLogEntry?> GetDriverWorkLogEntryById(Guid logId)
        {
            return await _manager.GetDriverWorkLogEntry(logId);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostDriverWorkLogEntry(DriverWorkLogEntry entry)
        {
            /* var entry = new DriverWorkLogEntry()
             {
             };*/

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid result = await _manager.PostDriverWorkLogEntry(entry);
            if (result == Guid.Empty)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{logId}")]
        public async Task<IActionResult> DeleteDriverWorkLogEntry(Guid logId)
        {
            Guid result = await _manager.DeleteDriverWorkLogEntry(logId);
            if (result == Guid.Empty)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
