using AutoMapper;
using ProfessionDriverApp.Business.Common;
using ProfessionDriverApp.Business.Searchers;
using ProfessionDriverApp.DataAccess.Repositories;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Business.Services
{
    public class EntityService : TService<Entity, EntitySearcher, IEntityRepository, int>, IEntityService
    {
        public EntityService(IMapper mapper, IEntityRepository entityRepository) : base(mapper, entityRepository) { }

        public override Task<int> Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Entity> Get(EntitySearcher? searcher = null)
        {
            var result = _repository.AllEntities;
            if (searcher != null)
            {
                var searched = searcher.Search();
                result.Where(searched);
            }
            return result;
        }

        public override Entity? GetSingle(int id)
        {
            throw new NotImplementedException();
        }
    }
}
