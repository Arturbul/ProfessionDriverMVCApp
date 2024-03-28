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
        public async Task<ICollection<EntityDTO>> GetEntity()
        {
            var entities = await _entityRepository.GetEntity();
            return entities.Select(e => new EntityDTO
            {
                EntityId = e.EntityId,
                EntityName = e.EntityName
            }).ToList();
        }

        public async Task<EntityDTO?> GetEntity(int id)
        {
            var entity = await _entityRepository.GetEntity(id);
            if (entity == null)
            {
                return null;
            }
            return new EntityDTO
            {
                EntityId = entity.EntityId,
                EntityName = entity.EntityName
            };
        }

        //POST
        public async Task<int> PostEntity(EntityDTO entityDTO)
        {
            var entity = new Entity
            {
                EntityName = entityDTO.EntityName
            };
            return await _entityRepository.PostEntity(entity);
        }

        //DELETE
        public async Task<int> DeleteEntity(int entityId)
        {
            return await _entityRepository.DeleteEntity(entityId);
        }
    }
}
