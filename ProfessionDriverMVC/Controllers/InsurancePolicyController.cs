using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers
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
        public async Task<ICollection<InsurancePolicy>> GetInsurancePolicys()
        {
            return await _manager.GetInsurancePolicy();
        }

        [HttpGet("{id}")]
        public async Task<InsurancePolicy?> GetInsurancePolicyById(int id)
        {
            return await _manager.GetInsurancePolicy(id);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostInsurancePolicy([FromBody] InsurancePolicy insurancePolicy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int result = await _manager.PostInsurancePolicy(insurancePolicy);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurancePolicy(int id)
        {
            int result = await _manager.DeleteInsurancePolicy(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
