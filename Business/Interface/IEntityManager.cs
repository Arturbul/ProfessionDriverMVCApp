using Domain.Models.DTO;
namespace Business.Interface
{
    public interface IEntityManager
    {
        Task<ICollection<EntityDTO>> GetEntity();
        Task<EntityDTO?> GetEntity(int id);
        Task<int> PostEntity(EntityDTO entity);
        Task<int> DeleteEntity(int entityId);
    }
}
