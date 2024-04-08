using Domain.ViewModels;

namespace Business.Interface
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeViewModel>> Get();
        Task<EmployeeViewModel?> Get(int id);
        Task<int> Create(EmployeeViewModel employeeViewModel);
        Task<int> Update(EmployeeViewModel employeeViewModel);
        Task<int> Delete(int employeeId);
    }
}
