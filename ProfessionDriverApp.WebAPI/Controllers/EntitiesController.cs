using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.ViewModels;


namespace ProfessionDriverApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/entities")]
    public class EntitiesController : Controller
    {
        private readonly IEntityService _manager;
        public EntitiesController(IEntityService manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<EntityViewModel>> Get()
        {
            var entitiesDTO = await _manager.Get();
            return entitiesDTO.Select(e => new EntityViewModel
            {
                EntityId = e.EntityId,
                EntityName = e.EntityName
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<EntityViewModel?> Get(int id)
        {
            var entity = await _manager.Get(id);
            if (entity == null)
            {
                return null;
            }
            return new EntityViewModel
            {
                EntityId = entity.EntityId,
                EntityName = entity.EntityName
            };
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(EntityViewModel entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.Create(entity);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }


        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = await _manager.Delete(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }


        //TEST
        [HttpPost("Test")]
        public int Test([FromQuery] string filter)
        {
            return 1;
        }

    }
}
