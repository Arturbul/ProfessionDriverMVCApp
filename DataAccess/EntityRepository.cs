using DataAccess.Interface;
using Domain.Data;
using Domain.Models;

namespace DataAccess
{
    public class EntityRepository : RepositoryBase, IEntityRepository
    {
        public EntityRepository(ProffesionDriverProjectContext context) : base(context)
        {
        }

        public async Task<ICollection<Entity>> Entities()
        {
            return await Task.FromResult(this.Context.Entitys.ToList());
        }
    }
}
