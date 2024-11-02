using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Domain.Interfaces
{
    public interface IAppUserProfile
    {
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
