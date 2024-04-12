namespace Business.Generic.Interface
{
    /// <summary>
    /// Generic manager
    /// </summary>
    /// <typeparam name="T"> Domain Model</typeparam>
    /// <typeparam name="TViewModel"> Domain's View Model of Model</typeparam>
    public interface ITManager<T, TViewModel>
        where T : class
        where TViewModel : class
    {
        Task<IEnumerable<TViewModel>> Get();
        Task<TViewModel?> Get<IdType>(IdType id);
        Task<TViewModel> Create(TViewModel viewModel);
        Task<TViewModel> Update(TViewModel viewModel);
        /// <summary>
        /// Delete method
        /// </summary>
        /// <typeparam name="IdType">ID's type</typeparam>
        /// <param name="id">value</param>
        /// <returns>number of changed records state</returns>
        Task<int> Delete<IdType>(IdType id);
    }
}
