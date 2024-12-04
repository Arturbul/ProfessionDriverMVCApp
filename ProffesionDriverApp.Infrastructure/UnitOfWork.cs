using ProfessionDriverApp.Domain.Interfaces;
using ProfessionDriverApp.Infrastructure.Interfaces;
using ProfessionDriverApp.Infrastructure.Repositories;

namespace ProfessionDriverApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProfessionDriverProjectContext _dbContext;
        private readonly IUserContextService _userContextService;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ProfessionDriverProjectContext dbContext, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _userContextService = userContextService;
        }

        public ITRepository<T> Repository<T>()
             where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repositoryType = typeof(TRepository<>);
                _repositories.Add(typeof(T), Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T))!, _dbContext, _userContextService)!);
            }
            return (ITRepository<T>)_repositories[typeof(T)];
        }

        public async Task<int> SaveToDatabaseAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
