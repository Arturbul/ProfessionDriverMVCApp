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
                 string? driverUserName,
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

        // Helper method
        private bool IsValidFilterType(string filterType)
        {
            var allowedFilters = new[] { "last7Days", "currentMonth", "currentYear", "custom" };
            return allowedFilters.Contains(filterType);
        }

        [Authorize]
        [HttpGet("hours")]
        public async Task<IActionResult> GetWorkedHours(
                string? driverUserName,
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
                distances = new List<object> //testing
                 {
                     new { month = "Jan", distance = 2000  },
                     new { month = "Feb", distance = 1800  },
                     new { month = "Mar", distance = 2200  },
                     new { month = "Apr", distance = 0  },
                     new { month = "May", distance = 2500  },
                     new { month = "Jun", distance = 0  },
                     new { month = "Jul", distance = 3200  },
                     new { month = "Aug", distance = 0  },
                     new { month = "Sep", distance = 2500  },
                     new { month = "Oct", distance = 0  },
                     new { month = "Nov", distance = 0  },
                     new { month = "Dec", distance = 4800  }
                 };
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
                /*logs = new List<DriverWorkLogSummaryDTO>
                 {
                     new DriverWorkLogSummaryDTO
                     {
                         DriverWorkLogId = Guid.NewGuid(),
                         StartPlace = "Warsaw",
                         EndPlace = "Krakow",
                         TotalDistance = 295.5f,
                         TotalHours = 4.5f,
                         VehicleNumber = "WZ12345",
                         TrailerNumber = "TR1234",
                         VehicleBrand = "Volvo"
                     },
                     new DriverWorkLogSummaryDTO
                     {
                         DriverWorkLogId = Guid.NewGuid(),
                         StartPlace = "Gdansk",
                         EndPlace = "Szczecin",
                         TotalDistance = 340.0f,
                         TotalHours = 5.2f,
                         VehicleNumber = "GD54321",
                         TrailerNumber = "TR5678",
                         VehicleBrand = "Scania"
                     },
                     new DriverWorkLogSummaryDTO
                     {
                         DriverWorkLogId = Guid.NewGuid(),
                         StartPlace = "Poznan",
                         EndPlace = "Wroclaw",
                         TotalDistance = 180.75f,
                         TotalHours = 3.0f,
                         VehicleNumber = "PO98765",
                         //TrailerNumber = "TR9012",
                         VehicleBrand = "Mercedes"
                     },
                     new DriverWorkLogSummaryDTO
                     {
                         DriverWorkLogId = Guid.NewGuid(),
                         StartPlace = "Poznan",
                         EndPlace = "Wroclaw",
                         TotalDistance = 180.75f,
                         TotalHours = 3.0f,
                         VehicleNumber = "PO98765",
                         //TrailerNumber = "TR9012",
                         VehicleBrand = "Mercedes"
                     },
                     new DriverWorkLogSummaryDTO
                     {
                         DriverWorkLogId = Guid.NewGuid(),
                         StartPlace = "Poznan",
                         EndPlace = "Wroclaw",
                         TotalDistance = 180.75f,
                         TotalHours = 3.0f,
                         VehicleNumber = "PO98765",
                         //TrailerNumber = "TR9012",
                         VehicleBrand = "Mercedes"
                     }
                 };*/
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
