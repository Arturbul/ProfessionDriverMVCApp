using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Application.Requests
{
    public class LinkUserToEmployeeRequest
    {
        public string UserName { get; set; } = null!;
        public string? EmployeeName { get; set; }
        public DateOnly? HireDate { get; set; }
        public Address? Address { get; set; }
    }
}