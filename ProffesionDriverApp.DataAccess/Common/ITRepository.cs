namespace ProfessionDriverApp.DataAccess.Common
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="T">Domain model</typeparam>
    public interface ITRepository<T>
        where T : class, new()
    {
        public IQueryable<T> AllEntities { get; }
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<int> Delete(T entity);
    }
}
