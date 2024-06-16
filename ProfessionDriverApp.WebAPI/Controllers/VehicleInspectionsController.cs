using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.Models;
namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/vehicle-inspections")]
    public class VehicleInspectionsController : Controller
    {
        private readonly IVehicleInspectionService _manager;
        public VehicleInspectionsController(IVehicleInspectionService manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<VehicleInspection>> GetVehicleInspections()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<VehicleInspection?> GetVehicleInspectionById(int id)
        {
            return await _manager.Get(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostVehicleInspection([FromBody] VehicleInspection vehicleInspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(vehicleInspection);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleInspection(int id)
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
