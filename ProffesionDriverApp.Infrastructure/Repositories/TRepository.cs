using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ValueObjects;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Infrastructure.Repositories
{
    public class TRepository<T> : ITRepository<T>
        where T : EntityBase
    {
        private readonly ProfessionDriverProjectContext _context;
        private readonly DbSet<T> _dbSet;

        public TRepository(ProfessionDriverProjectContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Queryable(EntityStatusFilter entityStatus = EntityStatusFilter.Exists)
        {
            var entities = _dbSet.AsQueryable();
            if (entityStatus == EntityStatusFilter.All)
            {
                return entities;
            }
            return entityStatus == EntityStatusFilter.Exists
                ? entities.Where(a => a.IsDeleted == false)
                    : entities.Where(a => a.IsDeleted == true);
        }

        public async Task<T?> GetByIdAsync(int id, EntityStatusFilter entityStatus = EntityStatusFilter.Exists)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entityStatus == EntityStatusFilter.All || entity == null)
                return entity;

            if (entityStatus == EntityStatusFilter.Deleted)
                return entity.IsDeleted ? entity : null;

            return !entity.IsDeleted ? entity : null;
        }

        public async void Add(T entity)
        {
            entity.Created = DateTime.UtcNow;
            //entity.Creator
            await _dbSet.AddAsync(entity);
        }

        // Aktualizacja encji
        public void Update(T entity)
        {
            entity.Modified = DateTime.UtcNow;
            //entity.Modifier
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.Modified = DateTime.UtcNow;
        }
    }
}
