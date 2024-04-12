namespace DataAccess.Generic.Interface
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="T">Domain model</typeparam>
    public interface ITRepository<T>
        where T : class, new()
    {
        Task<IEnumerable<T>> Get();
        /// <summary>
        /// gets an item
        /// </summary>
        /// <typeparam name="IdT">ID's type</typeparam>
        /// <param name="id">value</param>
        /// <returns>object of model or null</returns>
        Task<T?> Get<IdT>(IdT id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<int> Delete(T entity);
    }
}
