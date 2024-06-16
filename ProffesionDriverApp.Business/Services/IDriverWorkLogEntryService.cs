using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Business.Services
{
    public interface IDriverWorkLogEntryService
    {
        Task<IEnumerable<DriverWorkLogEntry>> Get();
        Task<DriverWorkLogEntry?> Get(Guid logId);
        Task<DriverWorkLogEntry> Create(DriverWorkLogEntry log);
        Task<DriverWorkLogEntry> Update(DriverWorkLogEntry log);
        Task<int> Delete(Guid LogId);
    }
}
