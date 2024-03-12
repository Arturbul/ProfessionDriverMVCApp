using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> PostEntity(Entity entity)
        {
            try
            {
                using (var context = this.Context)  // to ensure disposal
                {
                    context.Entitys.Add(entity);
                    await context.SaveChangesAsync();
                    return entity.EntityId;
                }
            }
            catch (DbUpdateException ex)  // Handle specific exception
            {
                throw new InvalidOperationException("Failed to create entity", ex);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
