using ProfessionDriverApp.Application.DTOs;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUserDTO?> GetAppUser(string? identifier);
        Task<IList<AppUserUnassignedDTO?>?> Unassigned();
    }
}
