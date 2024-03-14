using Domain.Models;

namespace Business.Interface
{
    public interface IEmployeeManager
    {
        Task<ICollection<Employee>> GetEmployee();
        Task<Employee?> GetEmployee(int id);
        Task<int> PostEmployee(Employee employee);
        Task<int> DeleteEmployee(int employeeId);
    }
}
