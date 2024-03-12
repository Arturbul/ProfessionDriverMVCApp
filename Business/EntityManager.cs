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
        public async Task<ICollection<Entity>> Entities()
        {
            return await _entityRepository.Entities();
        }

        public async Task<int> PostEntity(Entity entity)
        {
            return await _entityRepository.PostEntity(entity);
        }
    }
}
