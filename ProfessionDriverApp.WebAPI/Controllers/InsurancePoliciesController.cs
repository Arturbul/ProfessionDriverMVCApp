using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.Models;
namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/insurance-policies")]
    public class InsurancePoliciesController : Controller
    {
        private readonly IInsurancePolicyService _manager;
        public InsurancePoliciesController(IInsurancePolicyService manager)
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
