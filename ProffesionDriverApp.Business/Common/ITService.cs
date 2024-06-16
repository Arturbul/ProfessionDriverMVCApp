namespace ProfessionDriverApp.Business.Common
{
    /// <summary>
    /// Generic manager
    /// </summary>
    /// <typeparam name="T"> Domain Model</typeparam>
    /// <typeparam name="TViewModel"> Domain's View Model of Model</typeparam>
    public interface ITService<T, TSearcher, IdType>
        where T : class
        where TSearcher : class, new()
    {
        IQueryable<T> Get(TSearcher? searcher = null);
        T? GetSingle(IdType id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<int> Delete(IdType entity);
    }
}
