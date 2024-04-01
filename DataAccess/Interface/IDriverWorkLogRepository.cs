using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverWorkLogRepository
    {
        Task<ICollection<DriverWorkLog>> Get();
        Task<DriverWorkLog?> Get(Guid logId);
        Task<Guid> Create(DriverWorkLog log);
        Task<Guid> Update(DriverWorkLog log);
        Task<Guid> Delete(Guid LogId);
    }
}
