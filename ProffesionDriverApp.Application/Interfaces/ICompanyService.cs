using ProfessionDriverApp.Application.Requests;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface ICompanyService
    {
        Task Create(CreateCompanyRequest request);
        Task AssignUserToCompanyEmployee(LinkUserToEmployeeRequest request);
    }
}
