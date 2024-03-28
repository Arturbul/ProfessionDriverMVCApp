using Domain.Models.DTO;
namespace Business.Interface
{
    public interface IEmployeeManager
    {
        Task<ICollection<EmployeeDTO>> GetEmployee();
        Task<EmployeeDTO?> GetEmployee(int id);
        Task<int> PostEmployee(EmployeeDTO employee);
        Task<int> DeleteEmployee(int employeeId);
    }
}
