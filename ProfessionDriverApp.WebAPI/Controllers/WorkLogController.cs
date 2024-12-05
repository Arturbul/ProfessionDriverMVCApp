using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests.Create;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/worklog")]
    public class WorkLogController : Controller
    {
        private readonly IWorkLogService _workLogService;

        public WorkLogController(IWorkLogService workLogService)
        {
            _workLogService = workLogService;
        }

        [Authorize]
        [HttpGet("distance")]
        public async Task<IActionResult> GetDistance(string? companyName)
        {
            try
            {
                var entity = await _workLogService.TotalDistanceCompany(companyName);
                return Ok(entity);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User either has no company or unauthorized.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost("{starter:bool}")]
        public async Task<IActionResult> CreateWorkLogEntry(bool starter, CreateWorkLogEntryRequest request)
        {
            try
            {
                var entity = await _workLogService.MakeWorkLogEntry(starter, request);
                return Ok(entity);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User either has no company or unauthorized.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
