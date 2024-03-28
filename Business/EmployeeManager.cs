using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.Models.DTO;

namespace Business
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //GET
        public async Task<ICollection<EmployeeDTO>> GetEmployee()
        {
            var employees = await _employeeRepository.GetEmployee();
            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                EntityId = e.EmployeeId,
                HireDate = e.HireDate,
                TerminationDate = e.TerminationDate,
            }).ToList();
        }

        public async Task<EmployeeDTO?> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                EntityId = employee.EmployeeId,
                HireDate = employee.HireDate,
                TerminationDate = employee.TerminationDate,
            };
        }

        //POST
        public async Task<int> PostEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                EntityId = employeeDTO.EmployeeId,
                HireDate = employeeDTO.HireDate,
                TerminationDate = employeeDTO.TerminationDate
            };
            return await _employeeRepository.PostEmployee(employee);
        }

        //DELETE
        public async Task<int> DeleteEmployee(int employeeId)
        {
            return await _employeeRepository.DeleteEmployee(employeeId);
        }
    }
}
