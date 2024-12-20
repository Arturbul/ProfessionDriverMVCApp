﻿using Microsoft.AspNetCore.Identity;
using ProfessionDriverApp.Application.Interfaces;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRoleService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignRoleToUserAsync(AppUser user, string roleName)
        {
            // Check if the user is already in the role
            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                // Add user to the role
                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Failed to assign role to user.");
                }
            }
        }
    }
}
