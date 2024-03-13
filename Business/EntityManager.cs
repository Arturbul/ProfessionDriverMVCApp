using Business.Interface;
using DataAccess.Interface;
using Domain.Models;

namespace Business
{
    public class EntityManager : IEntityManager
    {
        private readonly IEntityRepository _entityRepository;
        public EntityManager(IEntityRepository repository)
        {
            _entityRepository = repository;
        }
        //GET
        public async Task<ICollection<Entity>> GetEntity()
        {
            return await _entityRepository.GetEntity();
        }

        public async Task<Entity?> GetEntity(int id)
        {
            return await _entityRepository.GetEntity(id);
        }

        //POST
        public async Task<int> PostEntity(Entity entity)
        {
            return await _entityRepository.PostEntity(entity);
        }

        //DELETE
        public async Task<int> DeleteEntity(int entityId)
        {
            return await _entityRepository.DeleteEntity(entityId);
        }
    }
}
