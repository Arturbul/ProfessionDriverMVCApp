using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverWorkLogDetailRepository
    {
        Task<ICollection<DriverWorkLogDetail>> GetDriverWorkLogDetail();
        Task<DriverWorkLogDetail?> GetDriverWorkLogDetail(Guid detailId);
        Task<Guid> PostDriverWorkLogDetail(DriverWorkLogDetail detail);
        Task<Guid> DeleteDriverWorkLogDetail(Guid detailId);
    }
}
