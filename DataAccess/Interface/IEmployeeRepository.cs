using Domain.Models;

namespace DataAccess.Interface
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetEmployee();
        Task<Employee?> GetEmployee(int id);
        Task<int> PostEmployee(Employee employee);
        Task<int> DeleteEmployee(int employeeId);
    }
}
