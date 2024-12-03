﻿using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Application.Requests.Update
{
    public class LinkUserToEmployeeRequest
    {
        public string UserName { get; set; } = null!;
        public string? EmployeeName { get; set; }
        public DateOnly? HireDate { get; set; }
        public Address? Address { get; set; }
    }
}