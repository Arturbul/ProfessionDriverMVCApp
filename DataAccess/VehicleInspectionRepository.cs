using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class VehicleInspectionRepository : RepositoryBase, IVehicleInspectionRepository
    {
        public VehicleInspectionRepository(ProfessionDriverProjectContext context) : base(context) { }
        //GET
        public async Task<ICollection<VehicleInspection>> GetVehicleInspection()
        {
            using var context = this.Context;
            var vehicleInspection = await context
                                    .VehicleInspections
                                    .AsNoTracking()
                                    .ToListAsync();

            return await Task.FromResult(vehicleInspection);
        }

        public async Task<VehicleInspection?> GetVehicleInspection(int id)
        {
            using var context = this.Context;
            var vehicleInspection = await context
                                    .VehicleInspections
                                    .Where(e => e.VehicleInspectionId == id)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync();

            return await Task.FromResult(vehicleInspection);
        }

        //POST
        public async Task<int> PostVehicleInspection(VehicleInspection vehicleInspection)
        {
            using var context = this.Context;
            context.VehicleInspections.Add(vehicleInspection);
            await context.SaveChangesAsync();

            return vehicleInspection.VehicleInspectionId;
        }

        //DELETE
        public async Task<int> DeleteVehicleInspection(int vehicleInspectionId)
        {
            using var context = this.Context;
            var vehicleInspection = await context.VehicleInspections.FindAsync(vehicleInspectionId);
            if (vehicleInspection != null)
            {
                context.VehicleInspections.Remove(vehicleInspection);
                await context.SaveChangesAsync();
                return vehicleInspection.VehicleInspectionId;
            }
            return 0;
        }
    }
}
