using Business.Interface;
using DataAccess.Interface;
using Domain.Models;
using Domain.Models.DTO;

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
        public async Task<IEnumerable<EntityDTO?>> Get()
        {
            var entities = await _entityRepository.Get();
            return entities.Select(e => (EntityDTO?)e);
        }

        public async Task<EntityDTO?> Get(int id)
        {
            var entity = await _entityRepository.Get(id);
            if (entity == null)
            {
                return null;
            }
            return (EntityDTO?)entity;
        }

        //POST
        public async Task<int> Create(EntityDTO entityDTO)
        {
            var entity = (Entity?)entityDTO;
            if (entity == null)
            {
                return 0;
            }
            return await _entityRepository.Create(entity);
        }
        public async Task<int> Update(EntityDTO entityDTO)
        {
            var entity = (Entity?)entityDTO;
            if (entity == null)
            {
                return 0;
            }
            return await _entityRepository.Update(entity);
        }

        //DELETE
        public async Task<int> Delete(int entityId)
        {
            return await _entityRepository.Delete(entityId);
        }
    }
}
