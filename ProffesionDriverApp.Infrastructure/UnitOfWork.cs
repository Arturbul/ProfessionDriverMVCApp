﻿using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure.Interfaces;
using ProfessionDriverApp.Infrastructure.Repositories;

namespace ProfessionDriverApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProfessionDriverProjectContext _dbContext;

        public UnitOfWork(ProfessionDriverProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly Dictionary<Type, object> _repositories = new();


        public ITRepository<T> Repository<T>()
            where T : EntityBase
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repositoryType = typeof(TRepository<>);
                _repositories.Add(typeof(T), Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T))!, _dbContext)!);
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
