using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Infrastructure.Interfaces
{
    public interface ITRepository<T>
        where T : EntityBase
    {
        public IQueryable<T> Queryable(EntityStatusFilter entityStatus = EntityStatusFilter.Exists);
        public Task<T?> GetByIdAsync(int id, EntityStatusFilter entityStatus = EntityStatusFilter.Exists);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
