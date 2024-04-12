using Domain.Models;

namespace Business.Interface
{
    public interface IVehicleManager
    {
        Task<IEnumerable<Vehicle>> Get();
        Task<Vehicle?> Get(int id);
        Task<Vehicle> Create(Vehicle vehicle);
        Task<Vehicle> Update(Vehicle vehicle);
        Task<int> Delete(int vehicleId);
    }
}
