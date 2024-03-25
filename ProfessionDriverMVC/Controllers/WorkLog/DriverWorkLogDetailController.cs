using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers.WorkLog
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverWorkLogDetailController : Controller
    {
        private readonly IDriverWorkLogDetailManager _manager;
        public DriverWorkLogDetailController(IDriverWorkLogDetailManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<DriverWorkLogDetail>> GetDriverWorkLogDetails()
        {
            return await _manager.GetDriverWorkLogDetail();
        }

        [HttpGet("{detailId}")]
        public async Task<DriverWorkLogDetail?> GetDriverWorkLogDetailById(Guid detailId)
        {
            return await _manager.GetDriverWorkLogDetail(detailId);
        }

        [HttpPost]
        public async Task<IActionResult> PostDriverWorkLogDetail([FromBody] DriverWorkLogDetail logDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid result = await _manager.PostDriverWorkLogDetail(logDetail);
            if (result == Guid.Empty)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{detailId}")]
        public async Task<IActionResult> DeleteDriverWorkLogDetail(Guid detailId)
        {
            Guid result = await _manager.DeleteDriverWorkLogDetail(detailId);
            if (result == Guid.Empty)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
