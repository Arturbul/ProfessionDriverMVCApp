using Domain.Models;

namespace Business.Interface
{
    public interface IVehicleInspectionManager
    {
        Task<ICollection<VehicleInspection>> Get();
        Task<VehicleInspection?> Get(int id);
        Task<int> Create(VehicleInspection vehicleInspection);
        Task<int> Update(VehicleInspection vehicleInspection);
        Task<int> Delete(int vehicleInspectionId);
    }
}
