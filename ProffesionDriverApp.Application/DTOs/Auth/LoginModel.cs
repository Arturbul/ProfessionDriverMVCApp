namespace ProfessionDriverApp.Application.DTOs.Auth
{
    public class LoginModel
    {
        public string? Identifier { get; set; }
        public string Password { get; set; } = null!;
    }
}
