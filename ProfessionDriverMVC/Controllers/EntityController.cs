using Business.Interface;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverMVC.ViewModels;

namespace ProfessionDriverMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : Controller
    {
        private readonly IEntityManager _manager;
        public EntityController(IEntityManager manager)
        {
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<EntityViewModel>> GetEntities()
        {
            var entitiesDTO = await _manager.GetEntity();
            return entitiesDTO.Select(e => new EntityViewModel
            {
                EntityId = e.EntityId,
                EntityName = e.EntityName
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<EntityViewModel?> GetEntityById(int id)
        {
            var entity = await _manager.GetEntity(id);
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
        public async Task<IActionResult> PostEntity(EntityDTO entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int result = await _manager.PostEntity(entity);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            int result = await _manager.DeleteEntity(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

    }
}
