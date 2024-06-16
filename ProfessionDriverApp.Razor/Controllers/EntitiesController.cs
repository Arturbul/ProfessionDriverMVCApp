using Microsoft.AspNetCore.Mvc;
using ProfessionDriverApp.Business.Services;
using ProfessionDriverApp.Domain.ViewModels;

namespace ProfessionDriverApp.RazorPages.Controllers
{
    public class EntitiesController : Controller
    {
        private readonly IEntityService _manager;
        public EntitiesController(IEntityService manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _manager.Get();
            return View(result.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _manager.Get((int)id);
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
                var result = await _manager.Create(entity);
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
            var entity = await _manager.Get((int)id);
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
                var result = await _manager.Update(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound(id);
            }
            var entity = await _manager.Get((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var entity = await _manager.Get(id);
            int result;
            if (entity != null)
            {
                result = await _manager.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
