using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IUserRoleService
    {
        Task AssignRoleToUserAsync(AppUser user, string roleName);
    }
}
