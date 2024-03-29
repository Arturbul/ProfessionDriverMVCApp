using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EntityRepository : RepositoryBase, IEntityRepository
    {
        public EntityRepository(ProfessionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<Entity>> GetEntity()
        {
            var entities = await this.Context
                                    .Entities
                                    .AsNoTracking()
                                    .ToListAsync();

            return entities;
        }

        public async Task<Entity?> GetEntity(int id)
        {
            var entity = await this.Context
                                    .Entities
                                    .Where(e => e.EntityId == id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            return entity;
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
