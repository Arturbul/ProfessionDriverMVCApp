using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class LGVRepository : RepositoryBase, ILGVRepository
    {
        public LGVRepository(ProfessionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<LargeGoodsVehicle>> GetLargeGoodsVehicle()
        {
            using var context = this.Context;
            var lgvs = await context
                                .LargeGoodsVehicles
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(lgvs);
        }

        public async Task<LargeGoodsVehicle?> GetLargeGoodsVehicle(int id)
        {
            using var context = this.Context;
            var lgvs = await context
                                .LargeGoodsVehicles
                                .Where(d => d.LargeGoodsVehicleId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(lgvs);
        }

        //POST
        public async Task<int> PostLargeGoodsVehicle(LargeGoodsVehicle lgv)
        {
            using var context = this.Context;
            context.LargeGoodsVehicles.Add(lgv);
            await context.SaveChangesAsync();

            return lgv.LargeGoodsVehicleId;
        }

        //DELETE
        public async Task<int> DeleteLargeGoodsVehicle(int lgvId)
        {
            using var context = this.Context;
            var lgv = await context
                                .LargeGoodsVehicles
                                .FindAsync(lgvId);
            if (lgv != null)
            {
                context.LargeGoodsVehicles.Remove(lgv);
                await context.SaveChangesAsync();

                return lgv.LargeGoodsVehicleId;
            }
            return 0;
        }
    }
}
