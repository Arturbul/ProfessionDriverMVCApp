using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using System.Security.Claims;

namespace ProfessionDriverApp.Application.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public UserContextService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public int? GetUserCompany()
        {
            var companyIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.GroupSid)?.Value;

            return int.TryParse(companyIdClaim, out var companyId) ? companyId : (int?)null;
        }

        public string? GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        }

    }
}
