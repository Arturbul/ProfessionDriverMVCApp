using ProfessionDriverApp.DataAccess.Common;
using ProfessionDriverApp.Domain.Data;
using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.DataAccess.Repositories
{
    public class EntityRepository : EFTRepository<Entity>, IEntityRepository
    {
        public EntityRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
