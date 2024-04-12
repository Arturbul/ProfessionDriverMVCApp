using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogDetailManager
    {
        Task<IEnumerable<DriverWorkLogDetail>> Get();
        Task<DriverWorkLogDetail?> Get(Guid detailId);
        Task<DriverWorkLogDetail> Create(DriverWorkLogDetail detail);
        Task<DriverWorkLogDetail> Update(DriverWorkLogDetail detail);
        Task<int> Delete(Guid detailId);
    }
}
