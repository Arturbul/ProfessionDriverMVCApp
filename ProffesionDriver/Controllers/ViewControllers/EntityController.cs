using Business.Interface;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverMVC.ViewModels;
using System.Linq;
using System.Threading.Tasks;

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
            var entities = await _manager.GetEntity();
            var result = entities.Cast<EntityViewModel?>();

            return View(result);
        }
    }
}
