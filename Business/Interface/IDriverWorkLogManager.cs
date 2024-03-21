using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogManager
    {
        Task<ICollection<DriverWorkLog>> GetDriverWorkLog();
        Task<DriverWorkLog?> GetDriverWorkLog(Guid logId);
        Task<Guid> PostDriverWorkLog(DriverWorkLog log);
        Task<Guid> DeleteDriverWorkLog(Guid LogId);
    }
}
