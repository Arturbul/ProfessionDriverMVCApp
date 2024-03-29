using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverMVC.ViewModels;

namespace ProfessionDriverMVC.Controllers.ViewControllers
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
            var entities = (ICollection<EntityViewModel>)await _manager.GetEntity();
            return View(entities);
        }
    }
}
