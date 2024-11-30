using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Application.Requests.Update;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface ICompanyService
    {
        Task Create(CreateCompanyRequest request);
        Task AssignUserToCompanyEmployee(LinkUserToEmployeeRequest request);
    }
}
