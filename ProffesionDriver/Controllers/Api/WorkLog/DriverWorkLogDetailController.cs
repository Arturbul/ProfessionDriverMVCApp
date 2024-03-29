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
        public async Task<ICollection<DriverWorkLogDetail>> Get()
        {
            return await _manager.GetDriverWorkLogDetail();
        }

        [HttpGet("{detailId}")]
        public async Task<DriverWorkLogDetail?> Get(Guid detailId)
        {
            return await _manager.GetDriverWorkLogDetail(detailId);
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

            Guid result = await _manager.PostDriverWorkLogDetail(logDetail);
            if (result == Guid.Empty)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{detailId}")]
        public async Task<IActionResult> Delete(Guid detailId)
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
