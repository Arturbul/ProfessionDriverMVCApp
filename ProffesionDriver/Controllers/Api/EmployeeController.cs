using Business.Interface;
using Domain.Models;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfessionDriver.Controllers.Api
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
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employeesDTO = await _employeeManager.GetEmployee();

            var entitiesDTO = new List<EntityDTO?>();
            foreach (var employee in employeesDTO)
            {
                var entity = await _entityManager.Get(employee.EntityId);
                entitiesDTO.Add(entity);
            }

            return employeesDTO.Select(e => new Employee
            {
                EmployeeId = e.EmployeeId,
                EntityId = e.EntityId,
                HireDate = e.HireDate,
                TerminationDate = e.TerminationDate,
                Entity = (Entity?)entitiesDTO.FirstOrDefault(entity => e.EntityId == entity?.EntityId) ?? new Entity()
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<Employee?> GetEmployeeById(int id)
        {
            var employee = await _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return null;
            }
            var entity = await _entityManager.Get(employee.EntityId);
            return new Employee
            {
                EmployeeId = employee.EmployeeId,
                EntityId = employee.EntityId,
                HireDate = employee.HireDate,
                TerminationDate = employee.TerminationDate,
                Entity = (Entity?)entity ?? new Entity()
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
