using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EntityRepository : RepositoryBase, IEntityRepository
    {
        public EntityRepository(ProffesionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<Entity>> GetEntity()
        {
            using var context = this.Context;
            var entities = await context
                                    .Entities
                                    .AsNoTracking()
                                    .ToListAsync();

            return await Task.FromResult(entities);
        }

        public async Task<Entity?> GetEntity(int id)
        {
            using var context = this.Context;
            var entity = await context
                                    .Entities
                                    .Where(e => e.EntityId == id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            return await Task.FromResult(entity);
        }

        //POST
        public async Task<int> PostEntity(Entity entity)
        {
            using var context = this.Context;
            context.Entities.Add(entity);
            await context.SaveChangesAsync();

            return entity.EntityId;
        }

        //DELETE
        public async Task<int> DeleteEntity(int entityId)
        {
            using var context = this.Context;
            var entity = await context.Entities.FindAsync(entityId);
            if (entity != null)
            {
                context.Entities.Remove(entity);
                await context.SaveChangesAsync();
                return entity.EntityId;
            }
            return 0;
        }

    }
}
