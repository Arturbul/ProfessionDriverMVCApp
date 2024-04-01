using Domain.Models;

namespace DataAccess.Interface
{
    public interface IDriverWorkLogDetailRepository
    {
        Task<ICollection<DriverWorkLogDetail>> Get();
        Task<DriverWorkLogDetail?> Get(Guid detailId);
        Task<Guid> Create(DriverWorkLogDetail detail);
        Task<Guid> Update(DriverWorkLogDetail detail);
        Task<Guid> Delete(Guid detailId);
    }
}
