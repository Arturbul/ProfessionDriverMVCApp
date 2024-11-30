using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ProfessionDriverApp.Application.DTOs.Auth;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Application.Requests;
using ProfessionDriverApp.Domain.Models;
using System.Text.RegularExpressions;

namespace ProfessionDriverApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRoleService _userRoleService;

        public UserService(IConfiguration configuration, IJwtService jwtService, UserManager<AppUser> userManager, IUserRoleService roleService)
        {
            _configuration = configuration;
            _jwtService = jwtService;
            _userManager = userManager;
            _userRoleService = roleService;
        }

        public async Task<object> RegisterUserAsync(RegistrationModel model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.Login);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with that login already exists.");
            }

            existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with that email already exists.");
            }

            var newUser = new AppUser
            {
                UserName = model.Login,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                throw new NullReferenceException(nameof(result));
            }

            var token = await _jwtService.GenerateJwtAsync(newUser);

            // Return the generated JWT token
            return _jwtService.WriteToken(token);
        }

        public async Task<object> Login(LoginModel model)
        {
            AppUser? user = null;

            // Find user by username or email
            if (!string.IsNullOrEmpty(model.Identifier))
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (Regex.IsMatch(model.Identifier, emailPattern))
                {
                    user = await _userManager.FindByEmailAsync(model.Identifier);
                }
                else
                {
                    user = await _userManager.FindByNameAsync(model.Identifier);
                }
            }

            // If user is not found or password is incorrect, throw an exception
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new InvalidOperationException("Incorrect identifier or password.");
            }

            // Generate JWT token for the authenticated user
            var token = await _jwtService.GenerateJwtAsync(user);

            // Return the generated JWT token
            return _jwtService.WriteToken(token);
        }
        public async Task<object> AssignUserToRole(AssignUserToRoleRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                throw new InvalidOperationException("Could not find user");

            await _userRoleService.AssignRoleToUserAsync(user, request.Role);

            var token = await _jwtService.GenerateJwtAsync(user);
            return _jwtService.WriteToken(token);
        }
    }
}
