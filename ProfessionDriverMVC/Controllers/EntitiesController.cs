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
        [HttpGet]
        public async Task<ICollection<Entity>> Entities()
        {
            return await _manager.Entities();
        }

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

            var result = _manager.PostEntity(entity);
            if (result.Result == 1)
            {
                Console.Error.WriteLine(result.Result);
            }
            return Ok(entity);
        }
    }
}
