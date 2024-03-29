using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfessionDriverMVC.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LargeGoodsVehicleController : Controller
    {
        private readonly ILGVManager _manager;
        public LargeGoodsVehicleController(ILGVManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<LargeGoodsVehicle>> GetLargeGoodsVehicles()
        {
            return await _manager.GetLargeGoodsVehicle();
        }

        [HttpGet("{id}")]
        public async Task<LargeGoodsVehicle?> GetLargeGoodsVehicleById(int id)
        {
            return await _manager.GetLargeGoodsVehicle(id);
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

            int result = await _manager.PostLargeGoodsVehicle(lgv);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLargeGoodsVehicle(int id)
        {
            int result = await _manager.DeleteLargeGoodsVehicle(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
