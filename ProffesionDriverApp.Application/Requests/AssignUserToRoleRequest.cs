﻿namespace ProfessionDriverApp.Application.Requests
{
    public class AssignUserToRoleRequest
    {
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}