using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.Api
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
