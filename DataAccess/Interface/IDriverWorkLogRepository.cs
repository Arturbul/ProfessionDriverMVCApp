using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverWorkLogRepository
    {
        Task<ICollection<DriverWorkLog>> GetDriverWorkLog();
        Task<DriverWorkLog?> GetDriverWorkLog(Guid logId);
        Task<Guid> PostDriverWorkLog(DriverWorkLog log);
        Task<Guid> DeleteDriverWorkLog(Guid LogId);
    }
}
