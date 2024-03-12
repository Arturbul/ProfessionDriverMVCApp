using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntitiesController : Controller
    {
        private readonly IEntityManager _manager;
        //private readonly ProffesionDriverProjectContext _context;
        public EntitiesController(/*ProffesionDriverProjectContext context,*/ IEntityManager manager)
        {
            //_context = context;
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<Entity>> GetEntities()
        {
            return await _manager.GetEntities();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostEntity(string? name)
        {
            var entity = new Entity()
            {
                EntityName = name
            };

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
        [HttpDelete]
        public async Task<IActionResult> DeleteEntity(int entityId)
        {
            int result = await _manager.DeleteEntity(entityId);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

    }
}
