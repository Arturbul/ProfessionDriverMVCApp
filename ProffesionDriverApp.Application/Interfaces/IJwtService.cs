using ProfessionDriverApp.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IJwtService
    {
        public Task<JwtSecurityToken> GenerateJwtAsync(AppUser user);
        public string WriteToken(JwtSecurityToken token);
        public ClaimsPrincipal? ValidateJwt(string token);
    }
}
