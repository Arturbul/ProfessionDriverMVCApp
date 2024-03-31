using Domain.Models.DTO;
namespace Business.Interface
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeDTO?>> Get();
        Task<EmployeeDTO?> Get(int id);
        Task<int> Create(EmployeeDTO employee);
        Task<int> Update(EmployeeDTO employee);
        Task<int> Delete(int employeeId);
    }
}
