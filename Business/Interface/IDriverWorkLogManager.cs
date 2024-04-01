using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogManager
    {
        Task<ICollection<DriverWorkLog>> Get();
        Task<DriverWorkLog?> Get(Guid logId);
        Task<Guid> Create(DriverWorkLog log);
        Task<Guid> Update(DriverWorkLog log);
        Task<Guid> Delete(Guid LogId);
    }
}
