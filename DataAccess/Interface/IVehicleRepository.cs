using Domain.Models;

namespace DataAccess.Interface
{
    public interface IVehicleRepository
    {
        Task<ICollection<Vehicle>> GetVehicle();
        Task<Vehicle?> GetVehicle(int id);
        Task<int> PostVehicle(Vehicle vehicle);
        Task<int> DeleteVehicle(int vehicleId);
    }
}
