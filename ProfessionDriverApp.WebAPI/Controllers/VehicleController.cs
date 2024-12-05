using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests.Create;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetVehicles(string? companyName)
        {
            try
            {
                var entities = await _vehicleService.GetVehicles(companyName);
                //return CreatedAtAction(nameof(GetDetails), new { registrationNumber = request.RegistrationNumber }, new { registrationNumber = request.RegistrationNumber });
                return Ok(entities);
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
        [HttpGet("{registrationNumber}")]
        public async Task<IActionResult> GetVehicle(string registrationNumber)
        {
            try
            {
                var entities = await _vehicleService.GetVehicle(registrationNumber);
                return Ok(entities);
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
        [HttpPost]
        public async Task<IActionResult> CreateNewVehicle(CreateVehicleRequest request)
        {
            try
            {
                var entityId = await _vehicleService.CreateVehicle(request);
                return CreatedAtAction(nameof(GetVehicle), new { registrationNumber = request.RegistrationNumber }, new { registrationNumber = request.RegistrationNumber });
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
