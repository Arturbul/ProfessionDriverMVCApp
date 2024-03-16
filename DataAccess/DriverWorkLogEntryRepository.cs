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
                                .DriverWorkLogEntries
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(driverWorkLogEntrys);
        }

        public async Task<DriverWorkLogEntry?> GetDriverWorkLogEntry(Guid id)
        {
            using var context = this.Context;
            var driverWorkLogEntrys = await context
                                .DriverWorkLogEntries
                                .Where(l => l.DriverWorkLogEntryId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(driverWorkLogEntrys);
        }

        //POST
        public async Task<Guid> PostDriverWorkLogEntry(DriverWorkLogEntry log)
        {
            using var context = this.Context;
            context.DriverWorkLogEntries.Add(log);
            await context.SaveChangesAsync();

            return log.DriverWorkLogEntryId;
        }

        //DELETE
        public async Task<Guid> DeleteDriverWorkLogEntry(Guid logId)
        {
            using var context = this.Context;
            var driverWorkLogEntry = await context
                                .DriverWorkLogEntries
                                .FindAsync(logId);
            if (driverWorkLogEntry != null)
            {
                context.DriverWorkLogEntries.Remove(driverWorkLogEntry);
                await context.SaveChangesAsync();

                return driverWorkLogEntry.DriverWorkLogEntryId;
            }
            return Guid.Empty;
        }
    }
}
