using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverWorkLogEntryRepository
    {
        Task<ICollection<DriverWorkLogEntry>> GetDriverWorkLogEntry();
        Task<DriverWorkLogEntry?> GetDriverWorkLogEntry(Guid logId);
        Task<Guid> PostDriverWorkLogEntry(DriverWorkLogEntry log);
        Task<Guid> DeleteDriverWorkLogEntry(Guid LogId);
    }
}
