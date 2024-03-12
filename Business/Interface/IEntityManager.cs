using Domain.Models;

namespace Business.Interface
{
    public interface IEntityManager
    {
        Task<ICollection<Entity>> Entities();
        Task<int> PostEntity(Entity entity);
    }
}
