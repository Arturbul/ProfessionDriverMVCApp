using ProfessionDriverApp.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IJwtService
    {
        public Task<JwtSecurityToken> GenerateJwtAsync(AppUser user);
        public object WriteToken(JwtSecurityToken token);
        public bool ValidateJwt(string token);
    }
}
