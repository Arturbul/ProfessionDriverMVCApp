using Microsoft.AspNetCore.Identity;
using ProfessionDriverApp.Application.DTOs.Auth;
using ProfessionDriverApp.Application.Requests;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegistrationModel model);
        Task<object> Login(LoginModel model);
        Task<object> AssignUserToRole(AssignUserToRoleRequest roleRequest);
    }
}
