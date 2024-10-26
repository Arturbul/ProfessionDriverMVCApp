namespace ProfessionDriverApp.Application.DTOs.Auth
{
    public class LoginResponse
    {
        public string JwtToken { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
    }
}
