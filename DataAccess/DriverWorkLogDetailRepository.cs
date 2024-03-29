using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DriverWorkLogDetailRepository : RepositoryBase, IDriverWorkLogDetailRepository
    {
        public DriverWorkLogDetailRepository(ProfessionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<DriverWorkLogDetail>> GetDriverWorkLogDetail()
        {
            using var context = this.Context;
            var driverWorkLogEntrys = await context
                                .DriverWorkLogDetails
                                //.Include(l => l.DriverWorkLog)
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(driverWorkLogEntrys);
        }

        public async Task<DriverWorkLogDetail?> GetDriverWorkLogDetail(Guid id)
        {
            using var context = this.Context;
            var driverWorkLogEntrys = await context
                                .DriverWorkLogDetails
                                //.Include(l => l.DriverWorkLog)
                                .Where(l => l.DriverWorkLogDetailId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(driverWorkLogEntrys);
        }

        //POST
        public async Task<Guid> PostDriverWorkLogDetail(DriverWorkLogDetail detail)
        {
            using var context = this.Context;
            context.DriverWorkLogDetails.Add(detail);
            await context.SaveChangesAsync();

            return detail.DriverWorkLogDetailId;
        }

        //DELETE
        public async Task<Guid> DeleteDriverWorkLogDetail(Guid detailId)
        {
            using var context = this.Context;
            var driverWorkLogEntry = await context
                                .DriverWorkLogDetails
                                .FindAsync(detailId);
            if (driverWorkLogEntry != null)
            {
                context.DriverWorkLogDetails.Remove(driverWorkLogEntry);
                await context.SaveChangesAsync();

                return driverWorkLogEntry.DriverWorkLogDetailId;
            }
            return Guid.Empty;
        }
    }
}
