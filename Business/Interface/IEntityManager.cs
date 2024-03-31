using Domain.Models.DTO;
namespace Business.Interface
{
    public interface IEntityManager
    {
        Task<IEnumerable<EntityDTO?>> Get();
        Task<EntityDTO?> Get(int id);
        Task<int> Create(EntityDTO entity);
        Task<int> Update(EntityDTO entity);
        Task<int> Delete(int entityId);
    }
}
