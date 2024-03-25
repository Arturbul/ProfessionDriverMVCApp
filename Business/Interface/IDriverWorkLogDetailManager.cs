using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogDetailManager
    {
        Task<ICollection<DriverWorkLogDetail>> GetDriverWorkLogDetail();
        Task<DriverWorkLogDetail?> GetDriverWorkLogDetail(Guid detailId);
        Task<Guid> PostDriverWorkLogDetail(DriverWorkLogDetail detail);
        Task<Guid> DeleteDriverWorkLogDetail(Guid detailId);
    }
}
