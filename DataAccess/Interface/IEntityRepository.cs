using Domain.Models;

namespace DataAccess.Interface
{
    public interface IEntityRepository
    {
        Task<ICollection<Entity>> Entities();
    }
}
