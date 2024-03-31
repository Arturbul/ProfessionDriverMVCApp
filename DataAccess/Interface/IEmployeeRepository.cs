using Domain.Models;

namespace DataAccess.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee?> Get(int id);
        Task<int> Create(Employee employee);
        Task<int> Update(Employee employee);
        Task<int> Delete(int employeeId);
    }
}
