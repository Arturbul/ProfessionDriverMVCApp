﻿using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Application.DTOs.Auth
{
    public class LoginModel
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; } = null!;
    }
}
