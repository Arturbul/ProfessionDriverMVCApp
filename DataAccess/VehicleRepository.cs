using DataAccess.Interface;
using Domain.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class VehicleRepository : RepositoryBase, IVehicleRepository
    {
        public VehicleRepository(ProffesionDriverProjectContext context) : base(context) { }

        //GET
        public async Task<ICollection<Vehicle>> GetVehicle()
        {
            using var context = this.Context;
            var vehicles = await context
                                .Vehicles
                                .AsNoTracking()
                                .ToListAsync();

            return await Task.FromResult(vehicles);
        }

        public async Task<Vehicle?> GetVehicle(int id)
        {
            using var context = this.Context;
            var vehicles = await context
                                .Vehicles
                                .Where(d => d.VehicleId == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();

            return await Task.FromResult(vehicles);
        }

        //POST
        public async Task<int> PostVehicle(Vehicle vehicle)
        {
            using var context = this.Context;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            return vehicle.VehicleId;
        }

        //DELETE
        public async Task<int> DeleteVehicle(int vehicleId)
        {
            using var context = this.Context;
            var vehicle = await context
                                .Vehicles
                                .FindAsync(vehicleId);
            if (vehicle != null)
            {
                context.Vehicles.Remove(vehicle);
                await context.SaveChangesAsync();

                return vehicle.VehicleId;
            }
            return 0;
        }
    }
}
