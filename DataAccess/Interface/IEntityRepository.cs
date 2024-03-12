using Domain.Models;

namespace DataAccess.Interface
{
    public interface IEntityRepository
    {
        Task<ICollection<Entity>> GetEntities();
        Task<Entity?> GetEntityById(int id);
        Task<int> PostEntity(Entity entity);
        Task<int> DeleteEntity(int entityId);
    }
}
