using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProfessionDriver.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsurancePolicyController : Controller
    {
        private readonly IInsurancePolicyManager _manager;
        public InsurancePolicyController(IInsurancePolicyManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<InsurancePolicy>> GetInsurancePolicys()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<InsurancePolicy?> GetInsurancePolicyById(int id)
        {
            return await _manager.Get(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostInsurancePolicy([FromBody] InsurancePolicy insurancePolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(insurancePolicy);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurancePolicy(int id)
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
