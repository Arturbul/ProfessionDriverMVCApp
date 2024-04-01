using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverWorkLogEntryRepository
    {
        Task<ICollection<DriverWorkLogEntry>> Get();
        Task<DriverWorkLogEntry?> Get(Guid logId);
        Task<Guid> Create(DriverWorkLogEntry log);
        Task<Guid> Update(DriverWorkLogEntry log);
        Task<Guid> Delete(Guid LogId);
    }
}
