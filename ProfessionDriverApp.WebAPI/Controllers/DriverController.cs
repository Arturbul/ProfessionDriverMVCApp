using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.Interfaces;

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
                 string? driverName,
                 string? filterType = null,
                 DateTime? startDate = null,
                 DateTime? endDate = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(filterType) && !IsValidFilterType(filterType))
                {
                    return BadRequest("Invalid filter type. Allowed values: 'last7Days', 'currentMonth', 'currentYear', or 'custom'.");
                }

                DateTime rangeStart;
                DateTime rangeEnd;

                switch (filterType)
                {
                    case "last7Days":
                        rangeStart = DateTime.UtcNow.AddDays(-7);
                        rangeEnd = DateTime.UtcNow;
                        break;

                    case "currentMonth":
                        rangeStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
                        rangeEnd = rangeStart.AddMonths(1).AddDays(-1);
                        break;

                    case "currentYear":
                        rangeStart = new DateTime(DateTime.UtcNow.Year, 1, 1);
                        rangeEnd = new DateTime(DateTime.UtcNow.Year, 12, 31);
                        break;

                    case "custom":
                        if (!startDate.HasValue || !endDate.HasValue)
                        {
                            return BadRequest("StartDate and EndDate are required for 'custom' filter type.");
                        }
                        rangeStart = startDate.Value;
                        rangeEnd = endDate.Value;
                        break;

                    default:
                        return BadRequest("Filter type is required. Allowed values: 'last7Days', 'currentMonth', 'currentYear', or 'custom'.");
                }

                if (rangeStart > rangeEnd)
                {
                    return BadRequest("StartDate cannot be greater than EndDate.");
                }

                var entity = await _workLogService.TotalDistanceDriver(driverName, rangeStart, rangeEnd);

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

        // Helper method
        private bool IsValidFilterType(string filterType)
        {
            var allowedFilters = new[] { "last7Days", "currentMonth", "currentYear", "custom" };
            return allowedFilters.Contains(filterType);
        }

        [Authorize]
        [HttpGet("worked-hours")]
        public async Task<IActionResult> GetWorkedHours(
                string? driverName,
                string? filterType = null,
                DateTime? startDate = null,
                DateTime? endDate = null)
        {
            try
            {
                // Sprawdzenie poprawności typu filtra
                if (!string.IsNullOrEmpty(filterType) && !IsValidFilterType(filterType))
                {
                    return BadRequest("Invalid filter type. Allowed values: 'last7Days', 'currentMonth', 'currentYear', or 'custom'.");
                }

                // Określenie zakresu dat na podstawie filtra
                DateTime rangeStart;
                DateTime rangeEnd;

                switch (filterType)
                {
                    case "last7Days":
                        rangeStart = DateTime.UtcNow.AddDays(-7);
                        rangeEnd = DateTime.UtcNow;
                        break;

                    case "currentMonth":
                        rangeStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
                        rangeEnd = rangeStart.AddMonths(1).AddDays(-1);
                        break;

                    case "currentYear":
                        rangeStart = new DateTime(DateTime.UtcNow.Year, 1, 1);
                        rangeEnd = new DateTime(DateTime.UtcNow.Year, 12, 31);
                        break;

                    case "custom":
                        if (!startDate.HasValue || !endDate.HasValue)
                        {
                            return BadRequest("StartDate and EndDate are required for 'custom' filter type.");
                        }
                        rangeStart = startDate.Value;
                        rangeEnd = endDate.Value;
                        break;

                    default:
                        return BadRequest("Filter type is required. Allowed values: 'last7Days', 'currentMonth', 'currentYear', or 'custom'.");
                }

                // Walidacja zakresu dat
                if (rangeStart > rangeEnd)
                {
                    return BadRequest("StartDate cannot be greater than EndDate.");
                }

                // Wywołanie serwisu liczącego przepracowane godziny
                var workedHours = await _workLogService.TotalWorkedHours(driverName, rangeStart, rangeEnd);

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
    }
}
