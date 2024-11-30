namespace ProfessionDriverApp.Application.DTOs
{
    public class AppUserDTO
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
