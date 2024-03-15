using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DriverWorkLogEntryRepository : RepositoryBase, IDriverWorkLogEntryRepository
    {
        public DriverWorkLogEntryRepository(ProffesionDriverProjectContext context) : base(context) { }
        //GET
        public async Task<ICollection<DriverWorkLogEntry>> GetDriverWorkLogEntry()
        {
            using var context = this.Context;
            var driverWorkLogEntrys = await context
                                .DriverWorkLogEntrys
                                .Include(d => d.Driver)
                                    .ThenInclude(e => e.Employee)
                                        .ThenInclude(en => en.Entity)
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(driverWorkLogEntrys);
        }

        public async Task<DriverWorkLogEntry?> GetDriverWorkLogEntry(Guid id)
        {
            using var context = this.Context;
            var driverWorkLogEntrys = await context
                                .DriverWorkLogEntrys
                                .Include(d => d.Driver)
                                    .ThenInclude(e => e.Employee)
                                        .ThenInclude(en => en.Entity)
                                .Where(l => l.DriverWorkLogEntryId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(driverWorkLogEntrys);
        }

        //POST
        public async Task<Guid> PostDriverWorkLogEntry(DriverWorkLogEntry log)
        {
            using var context = this.Context;
            context.DriverWorkLogEntrys.Add(log);
            await context.SaveChangesAsync();

            return log.DriverWorkLogEntryId;
        }

        //DELETE
        public async Task<Guid> DeleteDriverWorkLogEntry(Guid logId)
        {
            using var context = this.Context;
            var driverWorkLogEntry = await context
                                .DriverWorkLogEntrys
                                .FindAsync(logId);
            if (driverWorkLogEntry != null)
            {
                context.DriverWorkLogEntrys.Remove(driverWorkLogEntry);
                await context.SaveChangesAsync();

                return driverWorkLogEntry.DriverWorkLogEntryId;
            }
            return Guid.Empty;
        }
    }
}
