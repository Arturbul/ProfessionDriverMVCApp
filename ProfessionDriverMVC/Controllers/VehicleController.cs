using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IVehicleManager _manager;
        public VehicleController(IVehicleManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<Vehicle>> GetVehicles()
        {
            return await _manager.GetVehicle();
        }

        [HttpGet("{id}")]
        public async Task<Vehicle?> GetVehicleById(int id)
        {
            return await _manager.GetVehicle(id);
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

            int result = await _manager.PostVehicle(vehicle);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            int result = await _manager.DeleteVehicle(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
