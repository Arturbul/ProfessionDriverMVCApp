using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProfessionDriver.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleInspectionController : Controller
    {
        private readonly IVehicleInspectionManager _manager;
        public VehicleInspectionController(IVehicleInspectionManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<VehicleInspection>> GetVehicleInspections()
        {
            return await _manager.GetVehicleInspection();
        }

        [HttpGet("{id}")]
        public async Task<VehicleInspection?> GetVehicleInspectionById(int id)
        {
            return await _manager.GetVehicleInspection(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostVehicleInspection([FromBody] VehicleInspection vehicleInspection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int result = await _manager.PostVehicleInspection(vehicleInspection);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleInspection(int id)
        {
            int result = await _manager.DeleteVehicleInspection(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
