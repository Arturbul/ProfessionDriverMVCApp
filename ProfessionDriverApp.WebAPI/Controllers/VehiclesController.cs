using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _manager;
        public VehiclesController(IVehicleService manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<Vehicle?> GetVehicleById(int id)
        {
            return await _manager.Get(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostVehicle(string registrationNumber,
                                                         int? entityId,
                                                         string? brand,
                                                         string? model,
                                                         int? manufactureYear,
                                                         int? vehicleInsuranceId,
                                                         int? vehicleInspectionId)
        {
            var vehicle = new Vehicle()
            {
                RegistrationNumber = registrationNumber,
                EntityId = entityId,
                Brand = brand,
                Model = model,
                ManufactureYear = manufactureYear,
                VehicleInsuranceId = vehicleInsuranceId,
                VehicleInspectionId = vehicleInspectionId,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(vehicle);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            int result = await _manager.Delete(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
