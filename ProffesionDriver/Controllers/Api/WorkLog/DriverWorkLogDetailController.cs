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
    public class DriverWorkLogDetailController : Controller
    {
        private readonly IDriverWorkLogDetailManager _manager;
        public DriverWorkLogDetailController(IDriverWorkLogDetailManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<DriverWorkLogDetail>> Get()
        {
            return await _manager.Get();
        }

        [HttpGet("{detailId}")]
        public async Task<DriverWorkLogDetail?> Get(Guid detailId)
        {
            return await _manager.Get(detailId);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid driverWorkLogId, ICollection<DriverWorkLogEntry>? logEntries)
        {
            var logDetail = new DriverWorkLogDetail()
            {
                DriverWorkLogId = driverWorkLogId,
                DriverWorkLogEntries = logEntries
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(logDetail);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{detailId}")]
        public async Task<IActionResult> Delete(Guid detailId)
        {
            var result = await _manager.Delete(detailId);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
