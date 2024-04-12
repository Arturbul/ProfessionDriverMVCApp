
using DataAccess.Generic.Interface;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Generic
{
    public class EFTRepository<T> : ITRepository<T>
        where T : class, new()
    {
        private readonly ProfessionDriverProjectContext _context;
        public EFTRepository(ProfessionDriverProjectContext context)
        {
            _context = context;
        }

        //GET
        public async Task<IEnumerable<T>> Get()
        {
            var set = await _context
                .Set<T>()
                .ToListAsync();
            return set;
        }

        public async Task<T?> Get<IdT>(IdT id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        //POST
        public async Task<T> Create(T entity)
        {
            var added = _context.Entry(entity);
            added.State = EntityState.Added;

            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<T> Update(T entity)
        {
            var added = _context.Entry(entity);
            added.State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return added.Entity;
        }

        //DELETE
        public async Task<int> Delete(T entity)
        {
            var removed = _context.Entry(entity);
            removed.State = EntityState.Deleted;

            return await _context.SaveChangesAsync();
        }
    }
}
