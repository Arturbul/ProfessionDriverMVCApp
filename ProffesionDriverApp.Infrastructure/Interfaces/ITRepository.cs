using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Domain.ValueObjects;

namespace ProfessionDriverApp.Infrastructure.Interfaces
{
    public interface ITRepository<T>
        where T : class
    {
        public IQueryable<T> Queryable(bool filterCompany = true, EntityStatusFilter entityStatus = EntityStatusFilter.Exists);
        Task<T?> GetByIdAsync(int id, EntityStatusFilter entityStatus = EntityStatusFilter.Exists);
        Task Delete(int id);
        void FillEntityBase<TEntityBase>(TEntityBase entity) where TEntityBase : EntityBase;
        void DeleteFlagEntityBase<TEntityBase>(TEntityBase entity) where TEntityBase : EntityBase;
        void Add(T entity);
        void Update(T entity);
    }
}
