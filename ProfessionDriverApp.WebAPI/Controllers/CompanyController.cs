using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("details")]
        public async Task<IActionResult> GetDetails(string? name)
        {
            try
            {
                var entity = await _companyService.CompanyBasic(name);
                return Ok(entity);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User either has no company or unauthorized.");
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

        //PUT
        [Authorize]
        [HttpPut("details-basic")]
        public async Task<IActionResult> UpdateBasicDetails(string? name, UpdateCompanyRequest request)
        {
            try
            {
                await _companyService.UpdateCompanyBasics(name, request);
                return CreatedAtAction(nameof(GetDetails), new { name = name }, new { name = name });
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
        }

        //DELETE
        [Authorize(Roles = "Admin")]
        [HttpDelete("profiles/{id}")]
        public async Task<IActionResult> DeleteCompanyProfile(int id)
        {
            try
            {
                await _companyService.OffCompanyProfile(id);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return Problem(e.Message, statusCode: 500);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("profiles-employees/{id}")]
        public async Task<IActionResult> DeleteCompanyWithEmployees(int id)
        {
            try
            {
                await _companyService.OffCompanyProfileWithEmployees(id);
                return Ok();
            }
            catch (DbUpdateException e)
            {
                return Problem(e.Message, statusCode: 500);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

// endpoint dla pobrania konkretnego uzytkownika po -> identifier
// endpoint dla przypisania uzytkownika do firmy
// enpoint dla przypisania uzytkownika do firmy i przypisania do firmy
