namespace ProfessionDriverApp.Application.DTOs.Auth
{
    public class RefreshModel
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
