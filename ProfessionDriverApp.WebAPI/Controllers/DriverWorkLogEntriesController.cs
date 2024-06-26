﻿using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/driver-work-log-entries")]
    public class DriverWorkLogEntriesController : Controller
    {
        private readonly IDriverWorkLogEntryService _manager;
        public DriverWorkLogEntriesController(IDriverWorkLogEntryService manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<DriverWorkLogEntry>> Get()
        {
            return await _manager.Get();
        }

        [HttpGet("{logId}")]
        public async Task<DriverWorkLogEntry?> Get(Guid logId)
        {
            return await _manager.Get(logId);
        }

        //POST
        /// <summary>
        /// Adds a new driver work log entry.
        /// </summary>
        /// <param name="driverId">The identifier of the driver.</param>
        /// <param name="registrationNumber">The registration number of the vehicle.</param>
        /// <param name="time">
        /// The date and time of the work log entry in **DateTime** format (UTC recommended).
        /// See the **Remarks** section for the expected format.
        /// </param>
        /// <param name="place">The location where the work was performed (optional).</param>
        /// <param name="mileage">The mileage of the vehicle at the time of the entry (optional).</param>
        /// <returns>The unique identifier (GUID) of the newly created entry, or Guid.Empty if creation failed.</returns>
        /// <remarks>
        /// This method creates a new `DriverWorkLogEntry` object with the provided parameters and validates the data:
        /// - If validation fails, returns BadRequest.
        /// - If creation fails, returns NotFound.
        /// - Otherwise, returns the newly created entry's GUID.
        /// 
        /// ## Remarks: Accepted format for the `time` parameter
        /// 
        /// The `time` parameter should be provided in **DateTime** format, preferably using Coordinated Universal Time (UTC). 
        /// The expected format is: **"yyyy-MM-dd'T'HH:mm:ssZ"**.
        /// 
        /// **Example:**
        /// 
        /// ```json
        /// "time": "2024-03-16T13:00:00Z"
        /// ```
        /// </remarks>

        [HttpPost]
        public async Task<IActionResult> Post(int driverId, string registrationNumber, DateTime time, string? place, float? mileage, Guid? workLogDetailId)
        {
            var entry = new DriverWorkLogEntry()
            {
                DriverId = driverId,
                RegistrationNumber = registrationNumber,
                LogTime = time,
                Place = place,
                Mileage = mileage,
                //DriverWorkLogDetailId = workLogDetailId
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(entry);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{logId}")]
        public async Task<IActionResult> Delete(Guid logId)
        {
            var result = await _manager.Delete(logId);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
