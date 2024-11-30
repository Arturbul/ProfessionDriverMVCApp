using ProfessionDriverApp.Application.DTOs.Auth;
using ProfessionDriverApp.Application.Requests;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<object> RegisterUserAsync(RegistrationModel model);
        Task<object> Login(LoginModel model);
        Task<object> AssignUserToRole(AssignUserToRoleRequest roleRequest);
    }
}
