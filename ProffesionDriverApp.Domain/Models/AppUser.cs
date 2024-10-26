﻿using Microsoft.AspNetCore.Identity;

namespace ProfessionDriverApp.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? Created { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}