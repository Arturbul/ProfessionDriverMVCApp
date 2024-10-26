using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ITRepository<T> Repository<T>() where T : EntityBase;
        public Task<int> SaveToDatabaseAsync();
    }
}
