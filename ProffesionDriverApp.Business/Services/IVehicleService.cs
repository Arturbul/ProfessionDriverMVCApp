using ProfessionDriverApp.Domain.Models;

namespace ProfessionDriverApp.Business.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> Get();
        Task<Vehicle?> Get(int id);
        Task<Vehicle> Create(Vehicle vehicle);
        Task<Vehicle> Update(Vehicle vehicle);
        Task<int> Delete(int vehicleId);
    }
}
