using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriver.Controllers.Api
{
    [ApiController]
    [Route("api/lgv")]
    public class LargeGoodsVehiclesController : Controller
    {
        private readonly ILGVService _manager;
        public LargeGoodsVehiclesController(ILGVService manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<LargeGoodsVehicle>> GetLargeGoodsVehicles()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<LargeGoodsVehicle?> GetLargeGoodsVehicleById(int id)
        {
            return await _manager.Get(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostLargeGoodsVehicle(int vehicleId, int trailerId, DateOnly? tachoExpiryDate)
        {
            var lgv = new LargeGoodsVehicle()
            {
                VehicleId = vehicleId,
                TrailerId = trailerId,
                TachoExpiryDate = tachoExpiryDate
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(lgv);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLargeGoodsVehicle(int id)
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
