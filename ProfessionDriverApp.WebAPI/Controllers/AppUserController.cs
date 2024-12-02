using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.Interfaces;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AppUserController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet("unassigned")]
        public async Task<IActionResult> UnassignedUsers()
        {
            try
            {
                var result = await _appUserService.Unassigned();
                return Ok(result);
            }
            catch (InvalidOperationException e)
            {

                return NoContent();
            }
            catch (NullReferenceException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("details")]
        public async Task<IActionResult> UserDetails(string? identifier)
        {
            try
            {
                var result = await _appUserService.GetAppUser(identifier);
                return Ok(result);
            }
            catch (InvalidOperationException e)
            {
                return NoContent();
            }
            catch (NullReferenceException e)
            {
                return Conflict(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
