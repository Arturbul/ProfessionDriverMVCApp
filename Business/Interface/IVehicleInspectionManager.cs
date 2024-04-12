using Domain.Models;

namespace Business.Interface
{
    public interface IVehicleInspectionManager
    {
        Task<IEnumerable<VehicleInspection>> Get();
        Task<VehicleInspection?> Get(int id);
        Task<VehicleInspection> Create(VehicleInspection vehicleInspection);
        Task<VehicleInspection> Update(VehicleInspection vehicleInspection);
        Task<int> Delete(int vehicleInspectionId);
    }
}
