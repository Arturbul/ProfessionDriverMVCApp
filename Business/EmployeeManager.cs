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
        public async Task<IEnumerable<EmployeeDTO?>> Get()
        {
            var employees = await _employeeRepository.Get();
            return employees.Select(e => (EmployeeDTO?)e);
        }

        public async Task<EmployeeDTO?> Get(int id)
        {
            var employee = (EmployeeDTO?)await _employeeRepository.Get(id);
            return employee;
        }

        //POST
        public async Task<int> Create(EmployeeDTO employeeDTO)
        {
            var employee = (Employee?)employeeDTO;
            if (employee == null)
            {
                return 0;
            }
            return await _employeeRepository.Create(employee);
        }
        public async Task<int> Update(EmployeeDTO employeeDTO)
        {
            var employee = (Employee?)employeeDTO;
            if (employee == null)
            {
                return 0;
            }
            return await _employeeRepository.Update(employee);
        }

        //DELETE
        public async Task<int> Delete(int employeeId)
        {
            return await _employeeRepository.Delete(employeeId);
        }
    }
}
