using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Requests.Create;
using ProfessionDriverApp.Application.Requests.Update;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface ICompanyService
    {
        Task Create(CreateCompanyRequest request);
        Task AssignUserToCompanyEmployee(LinkUserToEmployeeRequest request);
        Task<IList<CompanyBasicDTO?>?> CompaniesWithDetails();
        Task<CompanyBasicDTO> CompanyBasic(string? name);
        Task<IList<CompanyBasicDTO?>?> CompaniesBasics();
        Task OffCompanyProfile(int id);
        Task OffCompanyProfileWithEmployees(int id);
        Task UpdateCompanyBasics(string? name, UpdateCompanyRequest request);
        Task<float> TotalDistance(string? name);
    }
}
