using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Domain.Models
{
    public class Employee : EntityBase, IAppUserProfile
    {
        public int EmployeeId { get; set; }

        public string? Name { get; set; }
        public Address? Address { get; set; }

        public DateOnly? HireDate { get; set; }
        public DateOnly? TerminationDate { get; set; }

        public bool IsEmployed => (TerminationDate == null || TerminationDate > DateOnly.FromDateTime(DateTime.UtcNow)) && (CompanyId != 0 || Company?.IsDeleted == false);
        public bool IsActive => IsEmployed && HireDate <= DateOnly.FromDateTime(DateTime.UtcNow);

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public override object Key => EmployeeId;
    }
}
