using Domain.Models;

namespace Business.Interface
{
    public interface IVehicleManager
    {
        Task<ICollection<Vehicle>> GetVehicle();
        Task<Vehicle?> GetVehicle(int id);
        Task<int> PostVehicle(Vehicle vehicle);
        Task<int> DeleteVehicle(int vehicleId);
    }
}
