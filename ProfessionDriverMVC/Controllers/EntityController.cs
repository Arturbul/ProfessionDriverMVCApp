﻿using Business.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityController : Controller
    {
        private readonly IEntityManager _manager;
        //private readonly ProffesionDriverProjectContext _context;
        public EntityController(/*ProffesionDriverProjectContext context,*/ IEntityManager manager)
        {
            //_context = context;
            _manager = manager;
        }

        //GET
        [HttpGet]
        public async Task<ICollection<Entity>> GetEntities()
        {
            return await _manager.GetEntity();
        }

        [HttpGet("{id}")]
        public async Task<Entity?> GetEntityById(int id)
        {
            return await _manager.GetEntity(id);
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