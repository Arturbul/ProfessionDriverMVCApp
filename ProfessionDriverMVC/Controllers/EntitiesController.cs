using Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ProfessionDriverMVC.Controllers
{
    public class EntitiesController : Controller
    {
        private readonly IEntityManager _manager;
        //private readonly ProffesionDriverProjectContext _context;
        public EntitiesController(/*ProffesionDriverProjectContext context,*/ IEntityManager manager)
        {
            //_context = context;
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var entities = await _manager.Entities();
            foreach (var item in entities)
            {
                Console.WriteLine(item.EntityName);
            }
            return View();
        }
    }
}
