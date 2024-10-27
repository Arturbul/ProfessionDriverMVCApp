using Microsoft.EntityFrameworkCore;
using ProfessionDriverApp.Domain.Interfaces;
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

        public void Add(T entity)
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }
            entity.IsDeleted = false;
            entity.Created = DateTime.UtcNow;
            entity.Creator = userName;
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var userName = _userContextService.GetUserName();
            if (userName == null)
            {
                throw new UnauthorizedAccessException();
            }
            entity.IsDeleted = false;
            entity.Modified = DateTime.UtcNow;
            entity.Modifier = userName;
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
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
