using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DriverWorkLogRepository : RepositoryBase, IDriverWorkLogRepository
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IDriverWorkLogEntryRepository _logEntryRepository;
        public DriverWorkLogRepository(ProffesionDriverProjectContext context,
            IDriverRepository driverRepository,
            IDriverWorkLogEntryRepository logEntryRepository)
            : base(context)
        {
            _driverRepository = driverRepository;
            _logEntryRepository = logEntryRepository;
        }

        //GET
        public async Task<ICollection<DriverWorkLog>> GetDriverWorkLog()
        {
            using var context = this.Context;
            var driverWorkLogs = await context
                                .DriverWorkLogs
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(driverWorkLogs);
        }

        public async Task<DriverWorkLog?> GetDriverWorkLog(Guid id)
        {
            using var context = this.Context;
            var driverWorkLogs = await context
                                .DriverWorkLogs
                                .Where(l => l.DriverWorkLogId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(driverWorkLogs);
        }

        //POST
        public async Task<Guid> PostDriverWorkLog(DriverWorkLog log)
        {
            using var context = this.Context;

            context.DriverWorkLogs.Add(log);
            await context.SaveChangesAsync();
            return log.DriverWorkLogId;
        }

        //DELETE
        public async Task<Guid> DeleteDriverWorkLog(Guid logId)
        {
            using var context = this.Context;
            var driverWorkLog = await context
                                .DriverWorkLogs
                                .FindAsync(logId);
            if (driverWorkLog != null)
            {
                context.DriverWorkLogs.Remove(driverWorkLog);
                await context.SaveChangesAsync();

                return driverWorkLog.DriverWorkLogId;
            }
            return Guid.Empty;
        }
    }
}
