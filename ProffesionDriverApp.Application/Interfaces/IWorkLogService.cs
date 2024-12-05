

using ProfessionDriverApp.Application.DTOs;
using ProfessionDriverApp.Application.Requests.Create;

namespace ProfessionDriverApp.Application.Interfaces
{
    public interface IWorkLogService
    {
        Task<List<object>> DistanceDriverYear(string? driverUserName);
        Task<List<DriverWorkLogSummaryDTO>> GetRecentDriverWorkLogs(string? driverUserName, int logCount = 5);
        Task<string> MakeWorkLogEntry(bool started, CreateWorkLogEntryRequest request);
        Task<float> TotalDistanceCompany(string? name, DateTime? startDate = null,
            DateTime? endDate = null);
        Task<float> TotalDistanceDriver(string? driverUserName, DateTime? startDate = null, DateTime? endDate = null);
        Task<TimeSpan> TotalWorkedHours(string? driverUserName, DateTime? startDate = null, DateTime? endDate = null);
    }
}
