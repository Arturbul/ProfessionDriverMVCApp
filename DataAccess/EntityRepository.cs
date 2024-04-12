using DataAccess.Generic;
using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class EntityRepository : EFTRepository<Entity>, IEntityRepository
    {
        public EntityRepository(ProfessionDriverProjectContext context) : base(context) { }
    }
}
