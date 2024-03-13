using Domain.Models;

namespace Business.Interface
{
    public interface IEntityManager
    {
        Task<ICollection<Entity>> GetEntity();
        Task<Entity?> GetEntity(int id);
        Task<int> PostEntity(Entity entity);
        Task<int> DeleteEntity(int entityId);
    }
}
