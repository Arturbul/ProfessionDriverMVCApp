using Domain.Models;

namespace DataAccess.Interface
{
    public interface IEntityRepository
    {
        Task<ICollection<Entity>> GetEntity();
        Task<Entity?> GetEntity(int id);
        Task<int> PostEntity(Entity entity);
        Task<int> DeleteEntity(int entityId);
    }
}
