using Domain.Models;

namespace DataAccess.Interface
{
    public interface IEntityRepository
    {
        Task<ICollection<Entity>> Get();
        Task<Entity?> Get(int id);
        Task<int> Create(Entity entity);
        Task<int> Update(Entity entity);
        Task<int> Delete(int entityId);
    }
}
