
namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IWorkLogService
    {
        Task<float> TotalDistance(string? name);
    }
}
