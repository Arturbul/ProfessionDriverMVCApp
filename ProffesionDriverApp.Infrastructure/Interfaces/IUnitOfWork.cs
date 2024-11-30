namespace ProfessionDriverApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ITRepository<T> Repository<T>() where T : class;
        public Task<int> SaveToDatabaseAsync();
    }
}
