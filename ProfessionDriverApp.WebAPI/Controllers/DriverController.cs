using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriverController : Controller
    {
        private readonly IWorkLogService _workLogService;

        public DriverController(IWorkLogService workLogService)
        {
            _workLogService = workLogService;
        }

        [Authorize]
        [HttpGet("distance")]
        public async Task<IActionResult> GetDistance(
            string? driverUserName,
            [FromQuery(Name = "filterType"), Required] FilterType filterType,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            try
            {
                DateTime rangeStart;
                DateTime rangeEnd;

                switch (filterType)
                {
                    case FilterType.Last7Days:
                        rangeStart = DateTime.UtcNow.AddDays(-7);
                        rangeEnd = DateTime.UtcNow;
                        break;

                    case FilterType.CurrentMonth:
                        rangeStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
                        rangeEnd = rangeStart.AddMonths(1).AddDays(-1);
                        break;

                    case FilterType.CurrentYear:
                        rangeStart = new DateTime(DateTime.UtcNow.Year, 1, 1);
                        rangeEnd = new DateTime(DateTime.UtcNow.Year, 12, 31);
                        break;

                    case FilterType.Custom:
                        if (!startDate.HasValue || !endDate.HasValue)
                        {
                            return BadRequest("StartDate and EndDate are required for 'custom' filter type.");
                        }
                        rangeStart = startDate.Value;
                        rangeEnd = endDate.Value;
                        break;

                    default:
                        return BadRequest("Invalid filter type.");
                }

                if (rangeStart > rangeEnd)
                {
                    return BadRequest("StartDate cannot be greater than EndDate.");
                }

                var result = await _workLogService.TotalDistanceDriver(driverUserName, rangeStart, rangeEnd);

                return Ok(result);
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
        [HttpGet("hours")]
        public async Task<IActionResult> GetWorkedHours(
                string? driverUserName,
                [FromQuery(Name = "filterType"), Required] FilterType filterType,
                DateTime? startDate = null,
                DateTime? endDate = null)
        {
            try
            {
                DateTime rangeStart;
                DateTime rangeEnd;

                switch (filterType)
                {
                    case FilterType.Last7Days:
                        rangeStart = DateTime.UtcNow.AddDays(-7);
                        rangeEnd = DateTime.UtcNow;
                        break;

                    case FilterType.CurrentMonth:
                        rangeStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
                        rangeEnd = rangeStart.AddMonths(1).AddDays(-1);
                        break;

                    case FilterType.CurrentYear:
                        rangeStart = new DateTime(DateTime.UtcNow.Year, 1, 1);
                        rangeEnd = new DateTime(DateTime.UtcNow.Year, 12, 31);
                        break;

                    case FilterType.Custom:
                        if (!startDate.HasValue || !endDate.HasValue)
                        {
                            return BadRequest("StartDate and EndDate are required for 'custom' filter type.");
                        }
                        rangeStart = startDate.Value;
                        rangeEnd = endDate.Value;
                        break;

                    default:
                        return BadRequest("Invalid filter type.");
                }

                if (rangeStart > rangeEnd)
                {
                    return BadRequest("StartDate cannot be greater than EndDate.");
                }

                var workedHours = await _workLogService.TotalWorkedHours(driverUserName, rangeStart, rangeEnd);

                return Ok(new
                {
                    Hours = workedHours.TotalHours,
                    Minutes = workedHours.TotalMinutes
                });
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
        [HttpGet("distance/year")]
        public async Task<IActionResult> GetDistanceByYear(string? driverUserName)
        {
            try
            {
                var distances = await _workLogService.DistanceDriverYear(driverUserName);
                return Ok(distances);
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
        [HttpGet("worklogs/recent")]
        public async Task<IActionResult> GetRecentDriverWorkLogs(int logCount = 5, string? driverUserName = null)
        {
            try
            {
                var logs = await _workLogService.GetRecentDriverWorkLogs(driverUserName, logCount);
                return Ok(logs);
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
