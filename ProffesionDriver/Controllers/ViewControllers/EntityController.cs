using Business.Interface;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriver.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.ViewControllers
{
    public class EntityController : Controller
    {
        private readonly IEntityManager _manager;
        public EntityController(IEntityManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _manager.GetEntity();
            return View(result.Select(e => (EntityViewModel?)e));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _manager.GetEntity((int)id);
            if (result == null)
            {
                return NotFound();
            }
            return View((EntityViewModel?)result);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EntityViewModel entity)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.PostEntity((EntityDTO)entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(id);
            }
            var entity = (EntityViewModel?)await _manager.GetEntity((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("EntityId,EntityName")] EntityViewModel entity)
        {
            if (id != entity.EntityId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // todo
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(id);
            }
            var entity = (EntityViewModel?)await _manager.GetEntity((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _manager.GetEntity(id);
            int result;
            if (entity != null)
            {
                result = await _manager.DeleteEntity(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
