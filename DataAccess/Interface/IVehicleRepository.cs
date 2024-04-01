using Domain.Models;

namespace DataAccess.Interface
{
    public interface IVehicleRepository
    {
        Task<ICollection<Vehicle>> Get();
        Task<Vehicle?> Get(int id);
        Task<int> Create(Vehicle vehicle);
        Task<int> Update(Vehicle vehicle);
        Task<int> Delete(int vehicleId);
    }
}
