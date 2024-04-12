using Business.Interface;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProfessionDriver.Controllers.Api
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

    }
}
