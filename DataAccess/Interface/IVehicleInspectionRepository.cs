using Domain.Models;

namespace DataAccess.Interface
{
    public interface IVehicleInspectionRepository
    {
        Task<ICollection<VehicleInspection>> Get();
        Task<VehicleInspection?> Get(int id);
        Task<int> Create(VehicleInspection vehicleInspection);
        Task<int> Update(VehicleInspection vehicleInspection);
        Task<int> Delete(int vehicleInspectionId);
    }
}
