using System.ComponentModel.DataAnnotations;

namespace ProfessionDriverApp.Application.DTOs.Auth
{
    public class RegistrationModel
    {
        public string UserName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
