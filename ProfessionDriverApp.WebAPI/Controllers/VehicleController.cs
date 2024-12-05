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
        [HttpPost]
        public async Task<IActionResult> CreateNewVehicle(CreateVehicleRequest request)
        {
            try
            {
                var entityId = await _vehicleService.CreateVehicle(request);
                //return CreatedAtAction(nameof(GetDetails), new { registrationNumber = request.RegistrationNumber }, new { registrationNumber = request.RegistrationNumber });
                return Created();
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
