using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProfessionDriverApp.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        /// <summary>
        /// Generates a JWT token for the given user and their roles.
        /// </summary>
        /// <param name="user">AppUser object representing the user.</param>
        /// <returns>JwtSecurityToken</returns>
        public async Task<JwtSecurityToken> GenerateJwtAsync(AppUser user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName))
            {
                throw new Exception("User is not valid");
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.GroupSid, user.CompanyId.ToString()??"")
            };

            // Fetch user roles and add them as claims
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured")));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddSeconds(
                    double.Parse(_configuration["JWTExtraSettings:TokenExpirySeconds"] ?? "4500000")),
                claims: authClaims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        /// <summary>
        /// Writes the JWT as a string.
        /// </summary>
        /// <param name="token">JwtSecurityToken object.</param>
        /// <returns>JWT string</returns>
        public object WriteToken(JwtSecurityToken token)
        {
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new { token = jwtToken };
        }

        /// <summary>
        /// Validates the JWT token.
        /// </summary>
        /// <param name="token">JWT string.</param>
        /// <returns>ClaimsPrincipal if the token is valid, null otherwise</returns>
        public bool ValidateJwt(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured"));

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["JWT:ValidIssuer"],
                    ValidAudience = _configuration["JWT:ValidAudience"],
                    ClockSkew = TimeSpan.FromSeconds(5),
                }, out SecurityToken validatedToken);

                return validatedToken != null;
            }
            catch (Exception)
            {
                throw new SecurityTokenValidationException();
            }
        }
    }
}
