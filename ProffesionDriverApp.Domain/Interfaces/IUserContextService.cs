using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Domain.Interfaces
{
    public interface IUserContextService
    {
        string? GetUserName();
        int? GetUserCompany();
        Task<AppUser> GetAppUser();
    }
}
