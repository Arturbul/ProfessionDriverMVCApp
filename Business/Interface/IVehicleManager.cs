using Domain.Models;

namespace Business.Interface
{
    public interface IVehicleManager
    {
        Task<ICollection<Vehicle>> Get();
        Task<Vehicle?> Get(int id);
        Task<int> Create(Vehicle vehicle);
        Task<int> Update(Vehicle vehicle);
        Task<int> Delete(int vehicleId);
    }
}
