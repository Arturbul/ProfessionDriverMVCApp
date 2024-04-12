using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogEntryManager
    {
        Task<IEnumerable<DriverWorkLogEntry>> Get();
        Task<DriverWorkLogEntry?> Get(Guid logId);
        Task<DriverWorkLogEntry> Create(DriverWorkLogEntry log);
        Task<DriverWorkLogEntry> Update(DriverWorkLogEntry log);
        Task<int> Delete(Guid LogId);
    }
}
