using Business.Interface;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using ProfessionDriverMVC.ViewModels;

namespace ProfessionDriverMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IEntityManager _entityManager;
        public EmployeeController(IEmployeeManager employeeManager, IEntityManager entityManager)
        {
            _employeeManager = employeeManager;
            _entityManager = entityManager;
        }

        //GET
        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            var employeesDTO = await _employeeManager.GetEmployee();

            var entitiesDTO = new List<EntityDTO?>();
            foreach (var employee in employeesDTO)
            {
                var entity = await _entityManager.GetEntity(employee.EntityId);
                entitiesDTO.Add(entity);
            }

            return employeesDTO.Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                HireDate = e.HireDate,
                TerminationDate = e.TerminationDate,
                EntityDTO = entitiesDTO.FirstOrDefault(entity => e.EntityId == entity?.EntityId)
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<EmployeeViewModel?> GetEmployeeById(int id)
        {
            var employee = await _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return null;
            }
            var entity = await _entityManager.GetEntity(employee.EntityId);
            return new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                HireDate = employee.HireDate,
                TerminationDate = employee.TerminationDate,
                EntityDTO = entity
            };
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int result = await _employeeManager.PostEmployee(employee);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            int result = await _employeeManager.DeleteEmployee(id);
            if (result == 0)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
