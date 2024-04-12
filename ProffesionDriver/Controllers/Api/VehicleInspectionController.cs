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
