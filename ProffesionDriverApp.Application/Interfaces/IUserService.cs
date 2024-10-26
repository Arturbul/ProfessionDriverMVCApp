using Microsoft.AspNetCore.Identity;
using ProfessionDriverApp.Application.DTOs.Auth;
using ProfessionDriverApp.Application.Requests;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegistrationModel model);
        Task<string> Login(LoginModel model);
        Task<string> AssignUserToRole(AssignUserToRoleRequest roleRequest);
    }
}
