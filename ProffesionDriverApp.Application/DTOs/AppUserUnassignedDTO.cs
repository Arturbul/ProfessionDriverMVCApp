namespace ProfessionDriverApp.Application.DTOs
{
    public class AppUserUnassignedDTO
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
