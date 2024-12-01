using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Application.Requests.Update;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService manager)
        {
            _companyService = manager;
        }

        //GET
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBasics()
        {
            try
            {
                var entities = await _companyService.CompaniesBasics();
                if (entities == null)
                {
                    return NoContent();
                }
                return Ok(entities);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("{name}")]
        public async Task<IActionResult> GetDetails(string name)
        {
            try
            {
                var entity = await _companyService.CompanyBasic(name);
                if (entity == null)
                {
                    return NoContent();
                }
                return Ok(entity);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //POST
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCompanyRequest request)
        {
            try
            {
                await _companyService.Create(request);
                return CreatedAtAction(nameof(GetDetails), new { name = request.Name }, new { name = request.Name });
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (InvalidOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPost("assign-user-to-company")]
        public async Task<IActionResult> AssignUserToCompanyEmployee(LinkUserToEmployeeRequest request)
        {
            try
            {
                await _companyService.AssignUserToCompanyEmployee(request);
            }
            catch (InvalidOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        //DELETE
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(1);

        }
    }
}

// endpoint dla pobrania konkretnego uzytkownika po -> identifier
// endpoint dla przypisania uzytkownika do firmy
// enpoint dla przypisania uzytkownika do firmy i przypisania do firmy
