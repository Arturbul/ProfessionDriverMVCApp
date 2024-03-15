using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogEntryManager
    {
        Task<ICollection<DriverWorkLogEntry>> GetDriverWorkLogEntry();
        Task<DriverWorkLogEntry?> GetDriverWorkLogEntry(Guid logId);
        Task<Guid> PostDriverWorkLogEntry(DriverWorkLogEntry log);
        Task<Guid> DeleteDriverWorkLogEntry(Guid LogId);
    }
}
