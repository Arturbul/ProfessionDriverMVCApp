using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogEntryManager
    {
        Task<ICollection<DriverWorkLogEntry>> Get();
        Task<DriverWorkLogEntry?> Get(Guid logId);
        Task<Guid> Create(DriverWorkLogEntry log);
        Task<Guid> Update(DriverWorkLogEntry log);
        Task<Guid> Delete(Guid LogId);
    }
}
