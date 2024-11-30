using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests;

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
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDTO?> Get(int id)
        {
            return null;

        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyRequest request)
        {
            try
            {
                await _companyService.Create(request);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message);
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
                throw new InvalidOperationException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
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

// endpoint dla pobrania nueprzypisanych uzytkownikow
// endpoint dla pobrania konkretnego uzytkownika po -> identifier
// endpoint dla przypisania uzytkownika do firmy
// enpoint dla przypisania uzytkownika do firmy i przypisania do firmy
