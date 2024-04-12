using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogManager
    {
        Task<IEnumerable<DriverWorkLog>> Get();
        Task<DriverWorkLog?> Get(Guid logId);
        Task<DriverWorkLog> Create(DriverWorkLog log);
        Task<DriverWorkLog> Update(DriverWorkLog log);
        Task<int> Delete(Guid LogId);
    }
}
