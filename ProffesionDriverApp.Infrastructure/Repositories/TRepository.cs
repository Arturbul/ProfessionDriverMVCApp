using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ValueObjects;
using ProfessionDriverApp.Infrastructure.Interfaces;

namespace ProfessionDriverApp.Infrastructure.Repositories
{
    public class TRepository<T> : ITRepository<T>
        where T : class
    {
        private readonly ProfessionDriverProjectContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IUserContextService _userContextService;

        public TRepository(ProfessionDriverProjectContext context, IUserContextService userContextService)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _userContextService = userContextService;
        }

        public IQueryable<T> Queryable(bool filterCompany = true, EntityStatusFilter entityStatus = EntityStatusFilter.Exists)
        {
            var entities = _dbSet.AsQueryable();

            if (filterCompany && typeof(ICompanyScope).IsAssignableFrom(typeof(T)))
            {
                var currentCompanyId = _userContextService.GetUserCompany();
                entities = entities.Where(e => ((ICompanyScope)e).CompanyId == currentCompanyId);
            }

            if (entityStatus != EntityStatusFilter.All && typeof(EntityBase).IsAssignableFrom(typeof(T)))
            {
                var baseEntities = entities.Cast<EntityBase>();

                var filtered = entityStatus == EntityStatusFilter.Exists
                    ? baseEntities.Where(a => a.IsDeleted == false)
                    : baseEntities.Where(a => a.IsDeleted == true);

                entities = filtered.Cast<T>();
            }
            return entities;
        }

        public async Task<T?> GetByIdAsync(int id, EntityStatusFilter entityStatus = EntityStatusFilter.Exists)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            if (entity is EntityBase baseEntity)
            {
                if (entityStatus == EntityStatusFilter.Deleted && !baseEntity.IsDeleted)
                    return null;

                if (entityStatus == EntityStatusFilter.Exists && baseEntity.IsDeleted)
                    return null;
            }

            return entity as T;
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity is EntityBase entityBase)
            {
                FillEntityBase(entityBase);
            }

            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity is EntityBase entityBase)
            {
                FillEntityBase(entityBase);
            }
            _dbSet.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            if (entity is EntityBase baseEntity)
            {
                DeleteEntityBase(baseEntity);
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity); // Hard delete
            }
        }

        public void FillEntityBase<TEntityBase>(TEntityBase entity)
            where TEntityBase : EntityBase
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }
            entity.IsDeleted = false;
            if (!entity.Created.HasValue || string.IsNullOrEmpty(entity.Creator))
            {
                entity.Created = DateTime.UtcNow;
                entity.Creator = userName;
            }
            entity.Modified = DateTime.UtcNow;
            entity.Modifier = userName;
        }

        public void DeleteEntityBase<TEntityBase>(TEntityBase entity)
            where TEntityBase : EntityBase
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }
            entity.IsDeleted = true;
            entity.Modified = DateTime.UtcNow;
            entity.Modifier = userName;
        }

    }
}
