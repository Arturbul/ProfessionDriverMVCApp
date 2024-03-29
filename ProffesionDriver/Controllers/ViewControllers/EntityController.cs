using Business.Interface;
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
    }
}
