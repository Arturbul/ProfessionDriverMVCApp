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
        [HttpPost("{started:bool}")]
        public async Task<IActionResult> CreateWorkLogEntry(bool started, CreateWorkLogEntryRequest request)
        {
            try
            {
                var entity = await _workLogService.MakeWorkLogEntry(started, request);
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
        [HttpGet]
        public async Task<IActionResult> GetWorkLogs(string? driverUserName)
        {
            try
            {
                var entity = await _workLogService.GetWorkLogs(driverUserName);
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLog(string id)
        {
            try
            {
                var entity = await _workLogService.GetWorkLog(id);
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
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestWorkLog(string? driverUserName, bool? active = null)
        {
            try
            {
                var entity = await _workLogService.GetLatestWorkLog(driverUserName, active);
                return Ok(entity);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
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

        /*  [Authorize]
          [HttpPut("{id}")]
          public async Task<IActionResult> UpdateWorkLogEntry(string id, CreateWorkLogEntryRequest request)
          {
              try
              {
                  *//*var entity = await _workLogService.MakeWorkLogEntry(id, request);
                  return Ok(entity);*//*
                  //TODO
                  return Ok(1);
              }
              catch (UnauthorizedAccessException)
              {
                  return Unauthorized("User either has no company or unauthorized.");
              }
              catch (Exception e)
              {
                  return BadRequest(e.Message);
              }
          }*/
    }
}
