using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Interfaces;

namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/individuals")]
    public class IndividualsController : Controller
    {
        private readonly IIndividualService _individualService;
        public IndividualsController(IIndividualService manager)
        {
            _individualService = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<IndividualDTO>> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public async Task<IndividualDTO?> Get(int id)
        {
            var userName = User.Identity?.Name; // Pobieranie nazwy użytkownika
            var a = await _individualService.Get();
            return null;

        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(IndividualDTO entity)
        {
            return null;

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
