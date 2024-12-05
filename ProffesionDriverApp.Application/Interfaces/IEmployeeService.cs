using ProfessionDriverApp.Application.DTOs;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeDTO?>?> GetEmployees(string? companyName);
    }
}
