using Domain.Models;

namespace Business.Interface
{
    public interface IDriverWorkLogDetailManager
    {
        Task<ICollection<DriverWorkLogDetail>> Get();
        Task<DriverWorkLogDetail?> Get(Guid detailId);
        Task<Guid> Create(DriverWorkLogDetail detail);
        Task<Guid> Update(DriverWorkLogDetail detail);
        Task<Guid> Delete(Guid detailId);
    }
}
