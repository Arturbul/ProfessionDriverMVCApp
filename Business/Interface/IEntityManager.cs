using Domain.Models;

namespace Business.Interface
{
    public interface IEntityManager
    {
        Task<ICollection<Entity>> GetEntities();
        Task<Entity?> GetEntityById(int id);
        Task<int> PostEntity(Entity entity);
        Task<int> DeleteEntity(int entityId);
    }
}
