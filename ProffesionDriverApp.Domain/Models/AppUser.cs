using Microsoft.AspNetCore.Identity;

namespace ProfessionDriverApp.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? Created { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }
    }
}