using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

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
        public async Task<ICollection<Employee>> GetEmployee()
        {
            return await _employeeRepository.GetEmployee();
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        //POST
        public async Task<int> PostEmployee(Employee employee)
        {
            return await _employeeRepository.PostEmployee(employee);
        }

        //DELETE
        public async Task<int> DeleteEmployee(int employeeId)
        {
            return await _employeeRepository.DeleteEmployee(employeeId);
        }
    }
}
